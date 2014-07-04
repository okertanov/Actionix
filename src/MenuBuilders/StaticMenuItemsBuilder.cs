using System;
using System.Linq;
using MonoMac.AppKit;
using System.Collections.Generic;

namespace Actionix
{
	//
	// Create static/hardcoded entires
	//
	public class StaticMenuItemsBuilder : IMenuItemsBuilder
	{
		private static readonly ShellCommandExecutor _shellCommandExecutor = new ShellCommandExecutor();
		private static readonly ApplicationCommandExecutor _applicationCommandExecutor = new ApplicationCommandExecutor();

		private static readonly Dictionary<string, Action> MenuItems = new Dictionary<string, Action>()
		{
			{ "Vim",			() => _applicationCommandExecutor.Execute("MacVim.app") 	},
			{ "Chrome",			() => _applicationCommandExecutor.Execute("Google Chrome.app")	},
			{ "Terminal",		() => _applicationCommandExecutor.Execute("Terminal.app")	},
			{ "Lock Screen",	() => _shellCommandExecutor.Execute("/System/Library/CoreServices/Menu%20Extras/user.menu/Contents/Resources/CGSession -suspend") 		}
		};

		public void AttachTo(NSMenu menu)
		{
			MenuItems.ToList().ForEach(item => menu.AddItem(new NSMenuItem(item.Key, "", OnMenu)));
		}

		private void OnMenu(object sender, EventArgs args)
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

