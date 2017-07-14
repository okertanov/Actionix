using System;
using MonoMac.AppKit;

namespace Actionix {
	public class VoidPeriodicEventMonitor : IPeriodicEventMonitor {
		public void Activate(Action<NSEvent> onEventMonitorAction) {
		}

		public void Dispose() {
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool disposing) {
		}

		~VoidPeriodicEventMonitor() {
			Dispose(false);
		}
	}
}