using System;
using MonoMac.AppKit;
using System.Drawing;
using TinyIoC;
using TinyMessenger;

namespace Actionix
{
	public static class Bootstrapper
	{
		private static readonly TinyIoCContainer container = TinyIoCContainer.Current;

		public static void Register()
		{
			container.Register<ITinyMessengerHub, TinyMessengerHub>().AsSingleton();
			container.Register<IApplicationCommandExecutor, ApplicationCommandExecutor>().AsSingleton();
			container.Register<ISelectorCommandExecutor, SelectorCommandExecutor>().AsSingleton();
			container.Register<IShellCommandExecutor, ShellCommandExecutor>().AsSingleton();
		}

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
            // See https://developer.apple.com/library/mac/documentation/Cocoa/Reference/ApplicationKit/Classes/NSEvent_Class/Reference/Reference.html
			// NSEvent.StartPeriodicEventsAfterDelay
			//

			/*var alert = new NSAlert();
			alert.MessageText = "Hi!";
			alert.InformativeText = "...";
			alert.RunModal();*/
		}
	}
}

