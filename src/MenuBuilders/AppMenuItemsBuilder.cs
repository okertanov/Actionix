using System;
using MonoMac.AppKit;

namespace Actionix
{
	public class AppMenuItemsBuilder : IMenuItemsBuilder
	{
		public void AttachTo(NSMenu menu)
		{
			menu.AddItem(new NSMenuItem("Quit", "", OnMenuQuit));
		}

		private void OnMenuQuit(object sender, EventArgs args)
		{
			NSApplication.SharedApplication.Terminate(NSApplication.SharedApplication);
		}
	}
}

