using System;
using MonoMac.AppKit;

namespace Actionix {
	public interface IMenuBuilder {
		NSMenu Build();
	}
}