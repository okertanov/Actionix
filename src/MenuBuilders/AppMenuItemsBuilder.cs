using System;
using MonoMac.AppKit;
using System.Collections.Generic;
using MonoMac.Foundation;

namespace Actionix
{
	//
	// Own app menu items
	//
	public class AppMenuItemsBuilder : BaseMenuItemsBuilder
	{
		private static readonly Dictionary<string, Action> AppMenuItems = new Dictionary<string, Action>()
		{
			{ "Quit", () => SelectorCommandExecutor.Execute("AppMenuItemsHandler.AppQuitCommand") },
		};

		protected override Dictionary<string, Action> MenuItems
		{
			get {
				return AppMenuItems;
			}

			set {
				throw new NotSupportedException();
			}
		}
	}

	internal class AppMenuItemsHandler
	{
		[Export("AppQuitCommand")]
		public static void AppQuitCommand()
		{
			NSApplication.SharedApplication.Terminate(NSApplication.SharedApplication);
		}
	}
}

