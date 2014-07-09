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
		protected static readonly IApplicationCommandExecutor _applicationCommandExecutor;
		protected static readonly ISelectorCommandExecutor _selectorCommandExecutor;
		protected static readonly IShellCommandExecutor _shellCommandExecutor;

		protected abstract Dictionary<string, Action> MenuItems { get; set; }

		static BaseMenuItemsBuilder()
		{
			_applicationCommandExecutor = TinyIoCContainer.Current.Resolve<IApplicationCommandExecutor>();
			_selectorCommandExecutor = TinyIoCContainer.Current.Resolve<ISelectorCommandExecutor>();
			_shellCommandExecutor = TinyIoCContainer.Current.Resolve<IShellCommandExecutor>();
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

