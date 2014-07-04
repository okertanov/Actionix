using System;
using System.Linq;
using MonoMac.AppKit;
using System.Collections.Generic;
using MonoMac.Foundation;
using MonoMac.ObjCRuntime;

namespace Actionix
{
	public class SelectorCommandContext : ICommandContext
	{
		public string SelectorName { get; set; }
	}

	public class SelectorCommandExecutor  : ICommandExecutor
	{
		public SelectorCommandExecutor()
		{
		}

		public void Execute(ICommandContext context)
		{
			var ctx = context as SelectorCommandContext;

			if (ctx != null)
			{
				Execute(ctx.SelectorName);
			}
		}

		// See http://stackoverflow.com/questions/10475415/how-do-i-send-parameters-using-monotouch-objcruntime-selector-and-perform-select
		public void Execute(string context)
		{
			var proxyObj = new NSObject();
			proxyObj.PerformSelector(new Selector(context), null, 0);
		}
	}
}

