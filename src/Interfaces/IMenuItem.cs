using System;

namespace Actionix {
	public interface IMenuItem {
		string Title { get; }
		Action Action { get; }
		string Icon { get; }
	}
}