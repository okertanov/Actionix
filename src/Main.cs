using System;
using MonoMac.AppKit;
using MonoMac.ObjCRuntime;

namespace Actionix
{
	class ActionixMain
	{
		static void Main(string[] args)
		{
			if (Dlfcn.dlopen("/Users/okertanov/projects/_github_/Actionix.git/src/Sdefs/libchrome-scripting.dylib", 0) == IntPtr.Zero)
			{
				Console.WriteLine("Unable to load the dynamic library.");
			}

			NSApplication.Init();
			NSApplication.SharedApplication.Delegate = new ActionixAppDelegate();
			NSApplication.Main(args);
		}
	}
}

