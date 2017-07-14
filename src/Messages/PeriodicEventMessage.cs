using TinyMessenger;
using MonoMac.AppKit;

namespace Actionix.Messages {
	public class PeriodicEventMessage : GenericTinyMessage<NSEvent> {
		public PeriodicEventMessage(object sender, NSEvent ev) : base(sender, ev) {
		}
	}
}