using System;
using MonoMac.AppKit;

namespace Actionix
{
	public class SeparatorMenuItemsBuilder : IMenuItemsBuilder
	{
		public void AttachTo(NSMenu menu)
		{
			menu.AddItem(NSMenuItem.SeparatorItem);
		}
	}
}

