using System;
using MonoMac.AppKit;

namespace Actionix {
	public interface IEventMonitor : IDisposable {
		void Activate(Action<NSEvent> onEventMonitorAction);
	}
}