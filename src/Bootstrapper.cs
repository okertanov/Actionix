using System;
using MonoMac.AppKit;
using System.Drawing;
using TinyIoC;
using TinyMessenger;

namespace Actionix
{
	public static class Bootstrapper
	{
		private static readonly TinyIoCContainer container = TinyIoCContainer.Current;

		public static void Register()
		{
			container.Register<ITinyMessengerHub, TinyMessengerHub>().AsSingleton();

			container.Register<IApplicationCommandExecutor, ApplicationCommandExecutor>().AsSingleton();
			container.Register<ISelectorCommandExecutor, SelectorCommandExecutor>().AsSingleton();
			container.Register<IShellCommandExecutor, ShellCommandExecutor>().AsSingleton();

			container.Register<IMenuExtraModule, MenuExtraModule>().AsSingleton();
		}

		public static void Bootstrap()
		{
			var extraModule = container.Resolve<IMenuExtraModule>();
			extraModule.Run();
		}

		public static void Terminate()
		{
			var hub = container.Resolve<ITinyMessengerHub>();
			var msg = new AppBeforeExitMessage(NSApplication.SharedApplication, null);
			hub.Publish(msg);
		}
	}
}

