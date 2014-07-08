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
			{ "Vim",				() => _applicationCommandExecutor.Execute("MacVim.app") },
			{ "Terminal",			() => _applicationCommandExecutor.Execute("Terminal.app") },
			{ "Google Chrome",		() => _applicationCommandExecutor.Execute("Google Chrome.app") },
			{ "--------", 			null },
			{ "System Preferences",	() => _applicationCommandExecutor.Execute("System Preferences.app") },
			{ "Lock Screen",		() => _shellCommandExecutor.Execute("/System/Library/CoreServices/Menu%20Extras/User.menu/Contents/Resources/CGSession -suspend") }
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

