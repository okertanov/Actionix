using System;
using System.Linq;
using MonoMac.AppKit;
using System.Collections.Generic;
using MonoMac.Foundation;
using MonoMac.ObjCRuntime;
using System.Reflection;
using TinyMessenger;

namespace Actionix
{
	public class SelectorCommandContext : ICommandContext
	{
		public object Target { get; set; }
		public string SelectorName { get; set; }
	}

	public class SelectorCommandExecutor  : ISelectorCommandExecutor
	{
		public SelectorCommandExecutor(ITinyMessengerHub hub)
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
		// See http://stackoverflow.com/questions/11908156/call-static-method-with-reflection
		public void Execute(string context)
		{
			var tokens = context.Split(new[]{'.'}, StringSplitOptions.RemoveEmptyEntries);
			var typeName = tokens.FirstOrDefault();
			var methodName = tokens.Skip(1).SingleOrDefault();

			var proxyType = Assembly.GetExecutingAssembly().GetTypes().Where(t => t.Name == typeName).SingleOrDefault();
			var proxyObj = Activator.CreateInstance(proxyType);
			var method = proxyType.GetMethod(methodName, BindingFlags.Public | BindingFlags.Static);
			method.Invoke(proxyObj, null);
		}
	}
}

