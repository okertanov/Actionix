using System;
using MonoMac.AppKit;

namespace Actionix
{
	//
	// Creates single separator
	//
	public class SeparatorMenuItemsBuilder : IMenuItemsBuilder
	{
		public void AttachTo(NSMenu menu)
		{
			menu.AddItem(NSMenuItem.SeparatorItem);
		}
	}
}

