using System;
using System.Linq;
using MonoMac.AppKit;
using System.Collections.Generic;

namespace Actionix
{
	//
	// Create static/hardcoded entires
	//
	public class StaticMenuItemsBuilder : BaseMenuItemsBuilder
	{
		private static readonly Dictionary<string, Action> StaticMenuItems = new Dictionary<string, Action>()
		{
			{ "Vim",				() => ApplicationCommandExecutor.Execute("MacVim.app") },
			{ "Terminal",			() => ApplicationCommandExecutor.Execute("Terminal.app") },
			{ "Google Chrome",		() => ApplicationCommandExecutor.Execute("Google Chrome.app") },
			{ "--------", 			null },
			{ "System Preferences",	() => ApplicationCommandExecutor.Execute("System Preferences.app") },
			{ "Lock Screen",		() => ShellCommandExecutor.Execute("/System/Library/CoreServices/Menu%20Extras/User.menu/Contents/Resources/CGSession -suspend") }
		};

		protected override Dictionary<string, Action> MenuItems
		{
			get {
				return StaticMenuItems;
			}

			set {
				throw new NotSupportedException();
			}
		}
	}
}

