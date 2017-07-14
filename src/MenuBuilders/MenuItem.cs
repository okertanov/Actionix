using System;

namespace Actionix.MenuBuilders {
	public class MenuItem : IMenuItem {
		public string Title { get; }
		public Action Action { get; }
		public string Icon { get; }

		public MenuItem(string title, Action action) : this(title, action, null) {
		}

		public MenuItem(string title, Action action, string icon) {
			Title = title;
			Action = action;
			Icon = icon;
		}
	}
}