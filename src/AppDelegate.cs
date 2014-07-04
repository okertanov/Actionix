using System;
using System.Drawing;
using MonoMac.Foundation;
using MonoMac.AppKit;
using MonoMac.ObjCRuntime;

namespace actionix
{
	[Register ("ActionixAppDelegate")]
	public class ActionixAppDelegate : NSApplicationDelegate
	{
		public ActionixAppDelegate ()
		{
		}

		public override void FinishedLaunching(NSObject notification)
		{
			var statusItem = NSStatusBar.SystemStatusBar.CreateStatusItem(24);
			statusItem.Title = @"";
			statusItem.Image = NSImage.ImageNamed("atom-20x20");
			statusItem.HighlightMode = true;

			var menu = new NSMenu("Actionix");
			menu.AddItem(NSMenuItem.SeparatorItem);
			menu.AddItem("Quit", new Selector("onMenuQuit"), "");
			statusItem.Menu = menu;
		}

		[Export("onMenuQuit")]
		private void OnMenuQuit()
		{
			NSApplication.SharedApplication.Terminate(this);
		}
	}
}

