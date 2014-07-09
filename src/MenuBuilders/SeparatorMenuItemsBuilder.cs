using System;
using MonoMac.AppKit;
using System.Collections.Generic;

namespace Actionix
{
	//
	// Creates single separator
	//
	public class SeparatorMenuItemsBuilder : BaseMenuItemsBuilder
	{
		private static readonly Dictionary<string, Action> SeparatorMenuItems = new Dictionary<string, Action>()
		{
			{ "--------", null },
		};

		protected override Dictionary<string, Action> MenuItems
		{
			get {
				return SeparatorMenuItems;
			}

			set {
				throw new NotSupportedException();
			}
		}
	}
}

