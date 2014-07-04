using System;
using System.Linq;

namespace Actionix
{
	public class ShellCommandContext : ICommandContext
	{
		public string CommandLine { get; set; }
	}

	public class ShellCommandExecutor : ICommandExecutor
	{
		public ShellCommandExecutor()
		{
		}

		public void Execute(ICommandContext context)
		{
			var ctx = context as ShellCommandContext;

			if (ctx != null)
			{
				Execute(ctx.CommandLine);
			}
		}

		public void Execute(string context)
		{
			var tokens = context.Split(new[]{' '}, StringSplitOptions.RemoveEmptyEntries);
			var command = tokens.FirstOrDefault();
			var parameters = String.Join(" ", tokens.Skip(1));
			System.Diagnostics.Process process = new System.Diagnostics.Process();
			System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
			startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
			startInfo.FileName = Uri.UnescapeDataString(command);
			startInfo.Arguments = Uri.UnescapeDataString(parameters);
			process.StartInfo = startInfo;
			process.Start();
		}
	}
}

