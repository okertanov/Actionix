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
			{ "New File on Desktop",	() => _selectorCommandExecutor.Execute("NewFileOnDesktop") },
			{ "New Vim Buffer",			() => _selectorCommandExecutor.Execute("NewVimBuffer") },
			{ "New Google Chrome Tab",	() => _selectorCommandExecutor.Execute("NewGoogleChromeTab") },
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

		[Export("NewFileOnDesktop")]
		private void NewFileOnDesktop()
		{

		}
	}
}

