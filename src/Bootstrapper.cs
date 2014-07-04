using System;
using MonoMac.AppKit;
using System.Drawing;

namespace Actionix
{
	public static class Bootstrapper
	{
		public static void Bootstrap()
		{
			//
			// Status bar menu
			//
			var systemStatusBarItem = NSStatusBar.SystemStatusBar.CreateStatusItem(SharedSettings.StatusBarIconSize.Width);

			var iconMenuVisualizer = new IconMenuVisualizer();
			iconMenuVisualizer.AttachTo(systemStatusBarItem);

			var menuBuilder = new MenuBuilder(SharedSettings.AppName, new IMenuItemsBuilder[] {
				new NewObjectMenuItemsBuilder(),
				new SeparatorMenuItemsBuilder(),
				new StaticMenuItemsBuilder(),
				new SeparatorMenuItemsBuilder(),
				new AppMenuItemsBuilder()
			});
			systemStatusBarItem.Menu = menuBuilder.Build();

			//
			// Global Shortcut Key Handler
			//
			// System Preferences > Security & Privacy > Privacy > Accessibility
			//
			var globalShortcutKeyMonitor = new GlobalShortcutKeyMonitor((ev) => {
				systemStatusBarItem.Menu.PopUpMenu(systemStatusBarItem.Menu.ItemAt(0), ev.LocationInWindow, null);
			});

			//
			// Periodic ticker
			// NSEvent.StartPeriodicEventsAfterDelay
			//


			/*var alert = new NSAlert();
			alert.MessageText = "Hi!";
			alert.InformativeText = "...";
			alert.RunModal();*/
		}
	}
}

