using System;
using MonoMac.AppKit;
using System.Drawing;

namespace Actionix
{
	public class SystemStatusBarItem : IMenuExtra
	{
		private readonly NSStatusItem _systemStatusBarItem;

		public SystemStatusBarItem()
		{
			_systemStatusBarItem = NSStatusBar.SystemStatusBar.CreateStatusItem(SharedSettings.StatusBarIconSize.Width);
		}

		public void AssignMenuVisualizer(IMenuVisualizer menuVisualizer)
		{
			menuVisualizer.AttachTo(_systemStatusBarItem);
		}

		public void AssignMenuBuilder(IMenuBuilder menuBuilder)
		{
			_systemStatusBarItem.Menu = menuBuilder.Build();
		}

		public void ShowMenuAt(PointF pointAt)
		{
			_systemStatusBarItem.Menu.PopUpMenu(_systemStatusBarItem.Menu.ItemAt(0), pointAt, null);
		}

		public void Dispose()
		{
			NSStatusBar.SystemStatusBar.RemoveStatusItem(_systemStatusBarItem);
		}
	}
}

