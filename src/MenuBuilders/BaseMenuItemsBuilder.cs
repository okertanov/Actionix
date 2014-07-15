using System;
using System.Linq;
using MonoMac.AppKit;
using System.Collections.Generic;
using TinyIoC;
using System.Collections;
using System.Drawing;

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

		protected abstract IList<IMenuItem> MenuItems { get; set; }

		static BaseMenuItemsBuilder()
		{
			ApplicationCommandExecutor = TinyIoCContainer.Current.Resolve<IApplicationCommandExecutor>();
			SelectorCommandExecutor = TinyIoCContainer.Current.Resolve<ISelectorCommandExecutor>();
			ShellCommandExecutor = TinyIoCContainer.Current.Resolve<IShellCommandExecutor>();
		}

		public virtual void AttachTo(NSMenu menu)
		{
			MenuItems.ToList().ForEach(item => {

				var menuItem = item.Title.StartsWith("-") ?
					NSMenuItem.SeparatorItem :
					new NSMenuItem(item.Title, "", OnMenu);
				if(!String.IsNullOrWhiteSpace(item.Icon))
				{
					var appIcon = new NSImage(item.Icon);
					appIcon.Size = SharedSettings.MenuItemIconSize;
					menuItem.Image = appIcon;
				}
				menu.AddItem(menuItem);
			});
		}

		protected virtual void OnMenu(object sender, EventArgs args)
		{
			var menuItem = sender as NSMenuItem;

			if (menuItem != null)
			{
				var action = MenuItems.Single(i => i.Title == menuItem.Title).Action;
				if (action != null)
				{
					action.Invoke();
				}
			}
		}
	}
}

