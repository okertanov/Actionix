using System;
using MonoMac.AppKit;
using MonoMac.Foundation;

namespace Actionix {
	public class IconMenuVisualizer : IMenuVisualizer {
		public void AttachTo(NSObject item) {
			var statusItem = item as NSStatusItem;
			statusItem.Title = String.Empty;
			var image = NSImage.ImageNamed(SharedSettings.StatusBarIconName);
			image.Size = SharedSettings.StatusBarIconSize;
			statusItem.Image = image;
			statusItem.HighlightMode = true;
		}
	}
}