using System;
using MonoMac.AppKit;
using System.Drawing;

namespace Actionix
{
	public class IconMenuVisualizer : IMenuVisualizer
	{
		public IconMenuVisualizer()
		{
		}

		public void AttachTo(NSStatusItem statusItem)
		{
			/*var statusItemView = new NSView(new RectangleF(0, 0, SharedSettings.StatusBarIconSize.Width, SharedSettings.StatusBarIconSize.Height));
			var imageView = new NSImageView(statusItemView.Bounds);
			imageView.Image = NSImage.ImageNamed(SharedSettings.StatusBarIconName);
			statusItemView.AddSubview(imageView);
			statusItem.View = statusItemView;
			var statusItemFrame = statusItem.View.Window.Frame;*/

			statusItem.Title = String.Empty;
			statusItem.Image = NSImage.ImageNamed(SharedSettings.StatusBarIconName);
			statusItem.HighlightMode = true;
		}
	}
}

