using System;
using System.Collections.Generic;
using System.IO;
using MonoMac.Foundation;

namespace Actionix {
	public class FileSystemHelperException : Exception {
		public FileSystemHelperException() : base() { }
		public FileSystemHelperException(string what) : base(what) { }
		public FileSystemHelperException(string what, Exception inner) : base(what, inner) { }
	}

	public static class FileSystemHelper {
		const int MaxUniqueFsNameProbes = 1 << 10;

		public static string Home {
			get {
				var nsHomePath = new NSString("~/");
				var expandedHomePath = nsHomePath.ExpandTildeInPath().ToString();
				return expandedHomePath;
			}
		}

		public static string Desktop {
			get {
				var nsDesktopPath = new NSString("~/Desktop");
				var expandedDesktopPath = nsDesktopPath.ExpandTildeInPath().ToString();
				return expandedDesktopPath;
			}
		}

		public static void CreateNewFile(string name) {
			File.Create(name);
		}

		public static string GenerateNonExistentFileNameAt<T>(string path, string nameMask, IEnumerator<T> uniquePartGenerator) {
			var fileName = String.Format(nameMask, uniquePartGenerator.Current);
			var filePath = Path.Combine(path, fileName);

			if (File.Exists(filePath)) {
				var count = 0;

				while (uniquePartGenerator.MoveNext()) {
					fileName = String.Format(nameMask, uniquePartGenerator.Current);
					filePath = Path.Combine(path, fileName);

					if (!File.Exists(filePath) || count++ > MaxUniqueFsNameProbes) {
						break;
					}
				}
			}

			return filePath;
		}
	}
}