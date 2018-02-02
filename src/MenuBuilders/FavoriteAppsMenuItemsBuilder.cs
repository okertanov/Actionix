using System.Collections.Generic;
using Actionix.Helpers;

namespace Actionix.MenuBuilders {
	//
	// Create static/hardcoded entires
	//
	public class FavoriteAppsMenuItemsBuilder : BaseMenuItemsBuilder {
		private static readonly IList<IMenuItem> FavoriteAppsMenuItems = new List<IMenuItem> {
			new MenuItem("Vim",                 () => ApplicationCommandExecutor.Execute("MacVim.app"), BundleUtils.ApplicationIconFromBundle("/Applications/MacVim.app")),
			new MenuItem("Notes",               () => ApplicationCommandExecutor.Execute("Notes.app"), BundleUtils.ApplicationIconFromBundle("/Applications/Notes.app")),
			new MenuItem("Terminal",            () => ApplicationCommandExecutor.Execute("Terminal.app"), BundleUtils.ApplicationIconFromBundle("/Applications/Utilities/Terminal.app")),
			new MenuItem("Google Chrome",       () => ApplicationCommandExecutor.Execute("Google Chrome.app"), BundleUtils.ApplicationIconFromBundle("/Applications/Google Chrome.app")),
			new MenuItem("Calculator",      	() => ApplicationCommandExecutor.Execute("Calculator.app"), BundleUtils.ApplicationIconFromBundle("/Applications/Calculator.app"))
		};

		protected override IList<IMenuItem> MenuItems => FavoriteAppsMenuItems;
	}
}