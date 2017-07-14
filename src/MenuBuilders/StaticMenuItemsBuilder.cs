﻿using System;
using System.Collections.Generic;

namespace Actionix {
	//
	// Create static/hardcoded entires
	//
	public class StaticMenuItemsBuilder : BaseMenuItemsBuilder {
		private static readonly IList<IMenuItem> StaticMenuItems = new List<IMenuItem> {
			new MenuItem("Vim",                 () => ApplicationCommandExecutor.Execute("MacVim.app"), BundleUtils.ApplicationIconFromBundle("/Applications/MacVim.app")),
			new MenuItem("Notes",               () => ApplicationCommandExecutor.Execute("Notes.app"), BundleUtils.ApplicationIconFromBundle("/Applications/Notes.app")),
			new MenuItem("Terminal",            () => ApplicationCommandExecutor.Execute("Terminal.app"), BundleUtils.ApplicationIconFromBundle("/Applications/Utilities/Terminal.app")),
			new MenuItem("Google Chrome",       () => ApplicationCommandExecutor.Execute("Google Chrome.app"), BundleUtils.ApplicationIconFromBundle("/Applications/Google Chrome.app")),
			new MenuItem("--------",            null),
			new MenuItem("System Preferences",  () => ApplicationCommandExecutor.Execute("System Preferences.app")),
			new MenuItem("Screen Saver",        () => ShellCommandExecutor.Execute("/System/Library/Frameworks/ScreenSaver.framework/Resources/ScreenSaverEngine.app/Contents/MacOS/ScreenSaverEngine")),
			new MenuItem("Lock Screen",         () => ShellCommandExecutor.Execute("/System/Library/CoreServices/Menu%20Extras/User.menu/Contents/Resources/CGSession -suspend"))
		};

		protected override IList<IMenuItem> MenuItems {
			get { return StaticMenuItems; }
			set { throw new NotSupportedException(); }
		}
	}
}