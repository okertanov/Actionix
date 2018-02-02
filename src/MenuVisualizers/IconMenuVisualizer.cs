using System;
using Actionix.App;
using MonoMac.AppKit;
using MonoMac.Foundation;
using MonoMac.CoreImage;
using MonoMac.CoreGraphics;

namespace Actionix.MenuVisualizers {
	public class IconMenuVisualizer : IMenuVisualizer {
		public void AttachTo(NSObject item) {
			var statusItem = item as NSStatusItem;
			statusItem.Title = String.Empty;
			var image = MakeGrayscaled(NSImage.ImageNamed(SharedSettings.StatusBarIconName));
			image.Size = SharedSettings.StatusBarIconSize;
			statusItem.Image = image;
			statusItem.HighlightMode = true;
		}

		private NSImage MakeGrayscaled(NSImage original) {
			var ciOriginal = CIImage.FromCGImage(original.CGImage);
			try {
				var filter = CIFilter.FromName("CIPhotoEffectNoir");
				filter.SetDefaults();
				filter.SetValueForKey(ciOriginal, MonoMac.CoreImage.CIFilterInputKey.Image);
				var ciFiltered = filter.ValueForKey(MonoMac.CoreImage.CIFilterOutputKey.Image) as CIImage;
				var repFiltered = new NSCIImageRep(ciFiltered);
				var nsFiltered = new NSImage(original.Size);
				nsFiltered.AddRepresentation(repFiltered);
				return nsFiltered;
			}
			catch (Exception e) {
				Console.Error.WriteLine("Error: " + e.Message ?? e.ToString());
				return original;
			}
		}
	}
}