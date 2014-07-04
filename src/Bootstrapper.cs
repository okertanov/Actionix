using System;
using MonoMac.AppKit;

namespace Actionix
{
	public static class Bootstrapper
	{
		public static void Bootstrap()
		{
			var systemStatusBarItem = NSStatusBar.SystemStatusBar.CreateStatusItem(24);

			var iconMenuVisualizer = new IconMenuVisualizer();
			iconMenuVisualizer.AttachTo(systemStatusBarItem);

			var menuBuilder = new MenuBuilder(SharedSettings.AppName, new IMenuItemsBuilder[] {
				new StaticMenuItemsBuilder(),
				new SeparatorMenuItemsBuilder(),
				new AppMenuItemsBuilder()
			});
			systemStatusBarItem.Menu = menuBuilder.Build();
		}
	}
}

