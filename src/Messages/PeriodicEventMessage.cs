using System;
using TinyMessenger;
using MonoMac.AppKit;

namespace Actionix
{
	public class PeriodicEventMessage : GenericTinyMessage<NSEvent>
	{
		public PeriodicEventMessage(object sender, NSEvent ev) : base(sender, ev)
		{
		}
	}
}

