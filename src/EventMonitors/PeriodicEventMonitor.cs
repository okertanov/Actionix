using System;
using MonoMac.AppKit;
using System.Threading;
using MonoMac.Foundation;

namespace Actionix
{
	public class PeriodicEventMonitor : IEventMonitor
	{
		private const double PeriodicEventMonitorDelay = 0.0;
		private const double PeriodicEventMonitorPeriod = 5.0;

		private Action<NSEvent> _onPeriodicEventMonitorAction;
		private Thread _threadWithRunLoop;

		//
		// Periodic ticker
		// See https://developer.apple.com/library/mac/documentation/Cocoa/Reference/ApplicationKit/Classes/NSEvent_Class/Reference/Reference.html
		// NSEvent.StartPeriodicEventsAfterDelay
		//
		public PeriodicEventMonitor(Action<NSEvent> onPeriodicEventMonitorAction)
		{
			_onPeriodicEventMonitorAction = onPeriodicEventMonitorAction;

			Install();
		}

		public void Install()
		{
			NSEvent.StartPeriodicEventsAfterDelay(PeriodicEventMonitorDelay, PeriodicEventMonitorPeriod);

			_threadWithRunLoop = new Thread(RunLoopThreadStart) { IsBackground = true };
			_threadWithRunLoop.Start();
		}

		public void Uninstall()
		{
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
						ev = app.NextEvent(NSEventMask.Periodic, NSDate.DistantPast, NSRunLoop.NSRunLoopEventTracking, true);
						if (ev != null) {
							evType = ev.Type;
						}
					});

					if (evType == NSEventType.Periodic)
					{
						if(_onPeriodicEventMonitorAction != null)
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

