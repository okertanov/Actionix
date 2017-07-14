using System;

namespace Actionix {
	public class MenuItem : IMenuItem {
		public string Title { get; private set; }
		public Action Action { get; private set; }
		public string Icon { get; private set; }

		public MenuItem(string title, Action action) : this(title, action, null) {
		}

		public MenuItem(string title, Action action, string icon) {
			Title = title;
			Action = action;
			Icon = icon;
		}
	}
}