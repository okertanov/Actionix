using System;
using System.Collections.Generic;
using System.Linq;
using Actionix.App;
using MonoMac.AppKit;
using TinyIoC;

namespace Actionix.MenuBuilders {
	//
	// Create static/hardcoded entires
	//
	public abstract class BaseMenuItemsBuilder : IMenuItemsBuilder {
		private static readonly TinyIoCContainer Container = TinyIoCContainer.Current;

		protected static readonly IApplicationCommandExecutor ApplicationCommandExecutor;
		protected static readonly ISelectorCommandExecutor SelectorCommandExecutor;
		protected static readonly IShellCommandExecutor ShellCommandExecutor;

		protected abstract IList<IMenuItem> MenuItems { get; }

		static BaseMenuItemsBuilder() {
			ApplicationCommandExecutor = Container.Resolve<IApplicationCommandExecutor>();
			SelectorCommandExecutor = Container.Resolve<ISelectorCommandExecutor>();
			ShellCommandExecutor = Container.Resolve<IShellCommandExecutor>();
		}

		public virtual void AttachTo(NSMenu menu) {
			MenuItems.ToList().ForEach(item => {
				var menuItem = item.Title.StartsWith("-", StringComparison.Ordinal) ?
					NSMenuItem.SeparatorItem :
					new NSMenuItem(item.Title, "", OnMenu);
				if (!String.IsNullOrWhiteSpace(item.Icon)) {
					var appIcon = new NSImage(item.Icon) {
						Size = SharedSettings.MenuItemIconSize
					};
					menuItem.Image = appIcon;
				}
				menu.AddItem(menuItem);
			});
		}

		protected virtual void OnMenu(object sender, EventArgs args) {
			var menuItem = sender as NSMenuItem;

			if (menuItem != null) {
				var action = MenuItems.Single(i => i.Title == menuItem.Title).Action;
				if (action != null) {
					action.Invoke();
				}
			}
		}
	}
}