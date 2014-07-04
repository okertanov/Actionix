using System;
using MonoMac.AppKit;

namespace Actionix
{
	public interface IMenuVisualizer
	{
		void AttachTo(NSStatusItem statusItem);
	}
}

