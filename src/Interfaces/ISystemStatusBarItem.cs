using System;
using MonoMac.AppKit;
using System.Drawing;
using TinyMessenger;

namespace Actionix
{
	public interface ISystemStatusBarItem : IMenuExtra
	{
		void AssignMenuBuilder(IMenuBuilder menuBuilder);
		void AssignMenuVisualizer(IMenuVisualizer menuVisualizer);
	}
}

