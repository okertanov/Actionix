using System;
using System.Collections.Generic;
using System.Linq;
using MonoMac.Foundation;

namespace Actionix {
	//
	// Creates new object entries, like new file on desktop, etc.
	//
	public class NewObjectMenuItemsBuilder : BaseMenuItemsBuilder {
		private static readonly IList<IMenuItem> NewObjectMenuItems = new List<IMenuItem>()
		{
			new MenuItem("New File on Desktop", () => SelectorCommandExecutor.Execute("NewObjectMenuItemsHandler.NewFileOnDesktop")),
			new MenuItem("New Google Chrome Tab",   () => SelectorCommandExecutor.Execute("NewObjectMenuItemsHandler.NewGoogleChromeTab"))
		};

		protected override IList<IMenuItem> MenuItems {
			get { return NewObjectMenuItems; }
			set { throw new NotSupportedException(); }
		}
	}

	internal class NewObjectMenuItemsHandler {
		private static IEnumerator<int> CreateIntegralSequenceEnumerator(int start) {
			return Enumerable.Range(start, int.MaxValue).GetEnumerator();
		}

		[Export("NewFileOnDesktop")]
		public static void NewFileOnDesktop() {
			var fileName = FileSystemHelper.GenerateNonExistentFileNameAt<int>(FileSystemHelper.Desktop, "New File {0}.txt", CreateIntegralSequenceEnumerator(1));
			if (!String.IsNullOrWhiteSpace(fileName)) {
				FileSystemHelper.CreateNewFile(fileName);
			}
		}

		[Export("NewGoogleChromeTab")]
		public static void NewGoogleChromeTab() {
			var chromeScripting = new Bindings.ChromeScripting(@"com.google.Chrome");
			chromeScripting.Activate();
			chromeScripting.OpenTab(String.Empty);
		}
	}
}