using System;
using MonoMac.AppKit;

namespace actionix
{
	class ActionixMain
	{
		static void Main(string[] args)
		{
			NSApplication.Init();
			NSApplication.SharedApplication.Delegate = new ActionixAppDelegate();
			NSApplication.Main(args);
		}
	}
}

