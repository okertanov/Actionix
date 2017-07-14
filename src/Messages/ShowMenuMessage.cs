using System;
using TinyMessenger;
using MonoMac.AppKit;

namespace Actionix {
	public class ShowMenuMessage : GenericTinyMessage<NSEvent> {
		public ShowMenuMessage(object sender, NSEvent ev) : base(sender, ev) {
		}
	}
}