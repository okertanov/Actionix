using System;
using MonoMac.AppKit;

namespace Actionix
{
	public class StaticMenuItemsBuilder : IMenuItemsBuilder
	{
		public void AttachTo(NSMenu menu)
		{
			menu.AddItem(new NSMenuItem("Vim", "", OnMenu));
			menu.AddItem(new NSMenuItem("Chrome", "", OnMenu));
			menu.AddItem(new NSMenuItem("Terminal", "", OnMenu));
		}

		private void OnMenu(object sender, EventArgs args)
		{
		}
	}
}

