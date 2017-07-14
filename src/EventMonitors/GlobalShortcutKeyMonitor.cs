using System;
using MonoMac.AppKit;
using MonoMac.Foundation;

namespace Actionix {
	public class GlobalShortcutKeyMonitor : IGlobalShortcutKeyMonitor {
		private NSObject _globalHandler;
		private NSObject _localHandler;
		private Action<NSEvent> _onGlobalShortcutKeyAction;

		private readonly object _lockObject = new object();

		public GlobalShortcutKeyMonitor() {
			Install();
		}

		public void Activate(Action<NSEvent> onGlobalShortcutKeyAction) {
			lock (_lockObject) {
				_onGlobalShortcutKeyAction = onGlobalShortcutKeyAction;
			}
		}

		public void Install() {
			_globalHandler = NSEvent.AddGlobalMonitorForEventsMatchingMask(NSEventMask.KeyDown, GlobalMonitorEventHandler);
			_localHandler = NSEvent.AddLocalMonitorForEventsMatchingMask(NSEventMask.KeyDown, LocalMonitorEventHandler);
		}

		public void Uninstall() {
			lock (_lockObject) {
				_onGlobalShortcutKeyAction = null;
			}

			NSEvent.RemoveMonitor(_localHandler);
			NSEvent.RemoveMonitor(_globalHandler);
		}

		private void GlobalMonitorEventHandler(NSEvent ev) {
			MonitorEventHandler(ev);
		}

		private NSEvent LocalMonitorEventHandler(NSEvent ev) {
			MonitorEventHandler(ev);

			return ev;
		}

		private void MonitorEventHandler(NSEvent ev) {
			if (ev.KeyCode == (ushort)IndependentKeycodes.kVK_DownArrow &&
				ev.ModifierFlags.HasFlag(NSEventModifierMask.CommandKeyMask) &&
				ev.ModifierFlags.HasFlag(NSEventModifierMask.AlternateKeyMask) &&
				ev.ModifierFlags.HasFlag(NSEventModifierMask.ControlKeyMask)) {
				if (_onGlobalShortcutKeyAction != null) {
					_onGlobalShortcutKeyAction.Invoke(ev);
				}
			}
		}

		public void Dispose() {
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool disposing) {
			Uninstall();
		}

		~GlobalShortcutKeyMonitor() {
			Dispose(false);
		}
	}
}