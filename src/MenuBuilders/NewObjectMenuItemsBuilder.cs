using System;
using MonoMac.AppKit;
using System.Collections.Generic;
using MonoMac.Foundation;

namespace Actionix
{
	//
	// Creates new object entries, like new file on desktop, etc.
	//
	public class NewObjectMenuItemsBuilder : BaseMenuItemsBuilder
	{
		private static readonly Dictionary<string, Action> NewObjectMenuItems = new Dictionary<string, Action>()
		{
			{ "New File on Desktop",	() => SelectorCommandExecutor.Execute("NewObjectMenuItemsHandler.NewFileOnDesktop") },
			{ "New Google Chrome Tab",	() => SelectorCommandExecutor.Execute("NewObjectMenuItemsHandler.NewGoogleChromeTab") },
		};

		protected override Dictionary<string, Action> MenuItems
		{
			get {
				return NewObjectMenuItems;
			}

			set {
				throw new NotSupportedException();
			}
		}
	}

	internal class NewObjectMenuItemsHandler
	{
		[Export("NewFileOnDesktop")]
		public static void NewFileOnDesktop()
		{
			var alert = new NSAlert();
			alert.MessageText = "...";
			alert.InformativeText = "NewFileOnDesktop";
			alert.RunModal();
		}

		[Export("NewGoogleChromeTab")]
		public static void NewGoogleChromeTab()
		{
			var alert = new NSAlert();
			alert.MessageText = "...";
			alert.InformativeText = "NewGoogleChromeTab";
			alert.RunModal();
		}
	}
}

