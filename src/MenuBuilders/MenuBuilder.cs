using System;
using System.Linq;
using MonoMac.AppKit;

namespace Actionix {
	public class MenuBuilder : IMenuBuilder {
		private string _menuName;
		private IMenuItemsBuilder[] _builders;

		public MenuBuilder(string menuName, IMenuItemsBuilder[] builders) {
			_menuName = menuName;
			_builders = builders;
		}

		public NSMenu Build() {
			var menu = new NSMenu(_menuName);

			if (_builders != null && _builders.Any()) {
				_builders.ToList().ForEach(builder => {
					builder.AttachTo(menu);
				});
			}

			return menu;
		}
	}
}