using System;

namespace Actionix
{
	public interface IEventMonitor : IDisposable
	{
		void Install();
		void Uninstall();
	}
}

