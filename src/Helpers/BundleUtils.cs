using System;
using MonoMac.Foundation;
using System.IO;

namespace Actionix
{
	public static class BundleUtils
	{
		private const string StdIconExtension = "icns";

		public static NSBundle BundleFromPath(string bundlePath)
		{
			return NSBundle.FromPath(bundlePath);
		}

		public static string ApplicationIconFromBundle(string bundlePath)
		{
			return ApplicationIconFromBundle(BundleFromPath(bundlePath));
		}

		public static string ApplicationIconFromBundle(NSBundle bundle)
		{
			var plistDict = NSDictionary.FromDictionary(bundle.InfoDictionary);
			var iconFullName = (plistDict.ValueForKey(new NSString("CFBundleIconFile")) as NSString).ToString();
			var iconName = Path.GetFileNameWithoutExtension(iconFullName);
			var iconExtension = Path.GetExtension(iconFullName);
			if (String.IsNullOrWhiteSpace(iconExtension)) {
				iconExtension = StdIconExtension;
			}
			var iconPath = bundle.PathForResource(iconName, iconExtension);

			return iconPath;
		}
	}
}

