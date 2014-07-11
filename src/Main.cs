using System;
using MonoMac.AppKit;
using MonoMac.ObjCRuntime;

namespace Actionix
{
	class ActionixMain
	{
		static void Main(string[] args)
		{
			NSApplication.Init();
			NSApplication.SharedApplication.Delegate = new ActionixAppDelegate();

			using (new DynamicLibScriptingActivator(SharedSettings.ChromeScriptingDlybName)) {
				NSApplication.Main(args);
			}
		}
	}
}

