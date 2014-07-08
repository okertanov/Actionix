using System;
using System.Linq;
using MonoMac.AppKit;
using System.Collections.Generic;

namespace Actionix
{
	public class ApplicationCommandContext : ICommandContext
	{
		public object Target { get; set; }
		public string BundleName { get; set; }
	}

	public class ApplicationCommandExecutor  : ICommandExecutor
	{
		public ApplicationCommandExecutor()
		{
		}

		public void Execute(ICommandContext context)
		{
			var ctx = context as ApplicationCommandContext;

			if (ctx != null)
			{
				Execute(ctx.BundleName);
			}
		}

		public void Execute(string context)
		{
			NSWorkspace.SharedWorkspace.LaunchApplication(context);
		}
	}
}

