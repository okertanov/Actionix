using System.Linq;
using MonoMac.AppKit;

namespace Actionix.MenuBuilders {
	public class MenuBuilder : IMenuBuilder {
		private readonly string _menuName;
		private readonly IMenuItemsBuilder[] _builders;

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