using System;
using System.Linq;
using MonoMac.AppKit;
using System.Collections.Generic;
using TinyIoC;

namespace Actionix
{
	//
	// Create static/hardcoded entires
	//
	public abstract class BaseMenuItemsBuilder : IMenuItemsBuilder
	{
		protected static readonly IApplicationCommandExecutor ApplicationCommandExecutor;
		protected static readonly ISelectorCommandExecutor SelectorCommandExecutor;
		protected static readonly IShellCommandExecutor ShellCommandExecutor;

		protected abstract Dictionary<string, Action> MenuItems { get; set; }

		static BaseMenuItemsBuilder()
		{
			ApplicationCommandExecutor = TinyIoCContainer.Current.Resolve<IApplicationCommandExecutor>();
			SelectorCommandExecutor = TinyIoCContainer.Current.Resolve<ISelectorCommandExecutor>();
			ShellCommandExecutor = TinyIoCContainer.Current.Resolve<IShellCommandExecutor>();
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

