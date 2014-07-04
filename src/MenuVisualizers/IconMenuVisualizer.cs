using System;
using MonoMac.AppKit;

namespace Actionix
{
	public class IconMenuVisualizer : IMenuVisualizer
	{
		public IconMenuVisualizer()
		{
		}

		public void AttachTo(NSStatusItem statusItem)
		{
			statusItem.Title = @"";
			statusItem.Image = NSImage.ImageNamed("atom-20x20");
			statusItem.HighlightMode = true;
		}
	}
}

