using System.Collections.Generic;

namespace Actionix.MenuBuilders {
	//
	// Create static/hardcoded entires
	//
	public class StaticMenuItemsBuilder : BaseMenuItemsBuilder {
		private static readonly IList<IMenuItem> StaticMenuItems = new List<IMenuItem> {
			new MenuItem("System Preferences",  () => ApplicationCommandExecutor.Execute("System Preferences.app")),
			new MenuItem("Screen Saver",        () => ShellCommandExecutor.Execute("/System/Library/Frameworks/ScreenSaver.framework/Resources/ScreenSaverEngine.app/Contents/MacOS/ScreenSaverEngine")),
			new MenuItem("Lock Screen",         () => ShellCommandExecutor.Execute("/System/Library/CoreServices/Menu%20Extras/User.menu/Contents/Resources/CGSession -suspend"))
		};

		protected override IList<IMenuItem> MenuItems => StaticMenuItems;
	}
}