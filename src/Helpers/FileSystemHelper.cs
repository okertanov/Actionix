using System;
using System.Collections.Generic;

namespace Actionix
{
	public class FileSystemHelperException : Exception
	{
		public FileSystemHelperException() : base() { }
		public FileSystemHelperException(string what) : base(what) { }
		public FileSystemHelperException(string what, Exception inner) : base(what, inner) { }
	}

	public class FileSystemHelper
	{
		const int MaxUniqueFsNameProbes = 1 << 10;

		public FileSystemHelper()
		{
		}

		public static void CreateNewFile(string name)
		{
			System.IO.File.Create(name);
		}

		public static string GenerateUniqueFileNameAt<T>(string path, string nameMask, IEnumerator<T> uniquePartGenerator)
		{
			var fileName = String.Empty;

			return fileName;
		}
	}
}

