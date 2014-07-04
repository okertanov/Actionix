using System;
using MonoMac.AppKit;

namespace Actionix
{
	public interface IMenuItemsBuilder
	{
		void AttachTo(NSMenu menu);
	}
}

