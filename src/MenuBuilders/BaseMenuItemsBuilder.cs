using System;
using System.Linq;
using MonoMac.AppKit;
using System.Collections.Generic;

namespace Actionix
{
	//
	// Create static/hardcoded entires
	//
	public abstract class BaseMenuItemsBuilder : IMenuItemsBuilder
	{
		protected static readonly ShellCommandExecutor _shellCommandExecutor = new ShellCommandExecutor();
		protected static readonly ApplicationCommandExecutor _applicationCommandExecutor = new ApplicationCommandExecutor();
		protected static readonly SelectorCommandExecutor _selectorCommandExecutor = new SelectorCommandExecutor();

		protected abstract Dictionary<string, Action> MenuItems { get; set; }

		public BaseMenuItemsBuilder() 
		{
		}

		public virtual void AttachTo(NSMenu menu)
		{
			MenuItems.ToList().ForEach(item => menu.AddItem(
				item.Key.StartsWith("-") ?
					NSMenuItem.SeparatorItem :
					new NSMenuItem(item.Key, "", OnMenu))
			);
		}

		protected virtual void OnMenu(object sender, EventArgs args)
		{
			var item = sender as NSMenuItem;

			if (item != null)
			{
				var action = MenuItems[item.Title];
				if (action != null)
				{
					action.Invoke();
				}
			}
		}
	}
}

