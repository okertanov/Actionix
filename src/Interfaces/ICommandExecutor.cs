using System;

namespace Actionix
{
	public interface ICommandExecutor
	{
		void Execute(ICommandContext context);
		void Execute(string context);
	}
}