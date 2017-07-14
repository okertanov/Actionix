using System.Drawing;

namespace Actionix.App {
	public static class SharedSettings {
		public const string AppName = "Actionix";

		public const string StatusBarIconName = "atom-512x512";
		public static readonly SizeF StatusBarIconSize = new SizeF(26, 26);
		public static readonly SizeF MenuItemIconSize = new SizeF(20, 20);

		public const string ChromeScriptingDlybName = "libchrome-scripting.dylib";
	}
}