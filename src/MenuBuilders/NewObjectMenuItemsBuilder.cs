using System;
using MonoMac.AppKit;
using System.Collections.Generic;
using MonoMac.Foundation;
using MonoMac.ScriptingBridge;
using System.Threading.Tasks;

namespace Actionix
{
	//
	// Creates new object entries, like new file on desktop, etc.
	//
	public class NewObjectMenuItemsBuilder : BaseMenuItemsBuilder
	{
		private static readonly IList<IMenuItem> NewObjectMenuItems = new List<IMenuItem>()
		{
			new MenuItem("New File on Desktop",	() => SelectorCommandExecutor.Execute("NewObjectMenuItemsHandler.NewFileOnDesktop")),
			new MenuItem("New Google Chrome Tab",	() => SelectorCommandExecutor.Execute("NewObjectMenuItemsHandler.NewGoogleChromeTab"))
		};

		protected override IList<IMenuItem> MenuItems
		{
			get { return NewObjectMenuItems; }
			set { throw new NotSupportedException(); }
		}
	}

	internal class NewObjectMenuItemsHandler
	{
		[Export("NewFileOnDesktop")]
		public static void NewFileOnDesktop()
		{
			FileSystemHelper helper = new FileSystemHelper();
		}

		[Export("NewGoogleChromeTab")]
		public static void NewGoogleChromeTab()
		{
			var chromeScripting = new Bindings.ChromeScripting(@"com.google.Chrome");
			chromeScripting.Activate();
			chromeScripting.OpenTab(String.Empty);
		}
	}
}

