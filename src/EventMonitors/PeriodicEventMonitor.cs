using System;
using MonoMac.AppKit;
using System.Threading;
using MonoMac.Foundation;

namespace Actionix
{
	public class PeriodicEventMonitor : IPeriodicEventMonitor
	{
		private const double PeriodicEventMonitorDelay = 0.0;
		private const double PeriodicEventMonitorPeriod = 3.0;

		private Action<NSEvent> _onPeriodicEventMonitorAction;
		private Thread _threadWithRunLoop;

		private readonly object _lockObject = new object();

		//
		// Periodic ticker
		// See https://developer.apple.com/library/mac/documentation/Cocoa/Reference/ApplicationKit/Classes/NSEvent_Class/Reference/Reference.html
		// NSEvent.StartPeriodicEventsAfterDelay
		//
		public PeriodicEventMonitor()
		{
			Install();
		}

		public void Activate(Action<NSEvent> onPeriodicEventMonitorAction)
		{
			lock (_lockObject)
			{
				_onPeriodicEventMonitorAction = onPeriodicEventMonitorAction;
			}
		}

		public void Install()
		{
			NSEvent.StartPeriodicEventsAfterDelay(PeriodicEventMonitorDelay, PeriodicEventMonitorPeriod);

			_threadWithRunLoop = new Thread(RunLoopThreadStart) { IsBackground = true };
			_threadWithRunLoop.Start();
		}

		public void Uninstall()
		{
			lock (_lockObject)
			{
				_onPeriodicEventMonitorAction = null;
			}

			_threadWithRunLoop.Abort();
			NSEvent.StopPeriodicEvents();
		}

		private void RunLoopThreadStart()
		{
			try
			{
				var app =  NSApplication.SharedApplication;
				do
				{
					NSEvent ev = null;
					NSEventType evType = NSEventType.ApplicationDefined;
					app.InvokeOnMainThread(() => {
						ev = app.NextEvent(NSEventMask.Periodic, NSDate.DistantPast, NSRunLoop.NSDefaultRunLoopMode, true);
						if (ev != null) {
							evType = ev.Type;
						}
					});

					Action<NSEvent> onPeriodicEventMonitorAction = null;
					lock(_lockObject)
					{
						onPeriodicEventMonitorAction = _onPeriodicEventMonitorAction;
					}

					if (evType == NSEventType.Periodic)
					{
						if(onPeriodicEventMonitorAction != null)
						{
							app.InvokeOnMainThread(() => {
								_onPeriodicEventMonitorAction.Invoke(ev);
							});
						}
					}
				}
				while(true);
			}
			catch(Exception e)
			{
			}
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool disposing)
		{
			Uninstall();
		}

		~PeriodicEventMonitor()
		{
			Dispose(false);
		}
	}
}

