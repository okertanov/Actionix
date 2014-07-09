using System;
using MonoMac.AppKit;
using System.Drawing;
using TinyIoC;
using TinyMessenger;

namespace Actionix
{
	public static class Bootstrapper
	{
		private static readonly TinyIoCContainer Container = TinyIoCContainer.Current;

		public static void Register()
		{
			Container.Register<ITinyMessengerHub, TinyMessengerHub>().AsSingleton();

			Container.Register<IApplicationCommandExecutor, ApplicationCommandExecutor>().AsSingleton();
			Container.Register<ISelectorCommandExecutor, SelectorCommandExecutor>().AsSingleton();
			Container.Register<IShellCommandExecutor, ShellCommandExecutor>().AsSingleton();

			Container.Register<IMenuExtraModule, MenuExtraModule>().AsSingleton();
		}

		public static void Bootstrap()
		{
			var extraModule = Container.Resolve<IMenuExtraModule>();
			extraModule.Run();
		}

		public static void Terminate()
		{
			var hub = Container.Resolve<ITinyMessengerHub>();
			var msg = new AppBeforeExitMessage(NSApplication.SharedApplication, null);
			hub.Publish(msg);
		}
	}
}

