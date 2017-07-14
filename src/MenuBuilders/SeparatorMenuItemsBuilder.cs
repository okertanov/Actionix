using System.Collections.Generic;

namespace Actionix {
	//
	// Creates single separator
	//
	public class SeparatorMenuItemsBuilder : BaseMenuItemsBuilder {
		private static readonly IList<IMenuItem> SeparatorMenuItems = new List<IMenuItem> {
			new MenuItem("--------", null)
		};

		protected override IList<IMenuItem> MenuItems => SeparatorMenuItems;
	}
}