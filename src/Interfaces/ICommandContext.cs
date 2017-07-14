using System;

namespace Actionix {
	public interface ICommandContext {
		object Target { get; set; }
	}
}