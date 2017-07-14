using Actionix.CommandExecutors;
using Actionix.EventMonitors;
using Actionix.Menu;
using Actionix.Messages;
using MonoMac.AppKit;
using TinyIoC;
using TinyMessenger;

namespace Actionix.App {
	public static class Bootstrapper {
		private static readonly TinyIoCContainer Container = TinyIoCContainer.Current;

		public static void Register() {
			Container.Register<ITinyMessengerHub, TinyMessengerHub>().AsSingleton();

			Container.Register<IApplicationCommandExecutor, ApplicationCommandExecutor>().AsSingleton();
			Container.Register<ISelectorCommandExecutor, SelectorCommandExecutor>().AsSingleton();
			Container.Register<IShellCommandExecutor, ShellCommandExecutor>().AsSingleton();


			Container.Register<IGlobalShortcutKeyMonitor, GlobalShortcutKeyMonitor>().AsSingleton();
			Container.Register<IPeriodicEventMonitor, VoidPeriodicEventMonitor>().AsSingleton();

			Container.Register<ISystemStatusBarItem, SystemStatusBarItem>().AsSingleton();
			Container.Register<IMenuExtraModule, MenuExtraModule>().AsSingleton();
		}

		public static void Bootstrap() {
			var extraModule = Container.Resolve<IMenuExtraModule>();
			extraModule.Run();
		}

		public static void Terminate() {
			var hub = Container.Resolve<ITinyMessengerHub>();
			var msg = new AppBeforeExitMessage(NSApplication.SharedApplication, null);
			hub.Publish(msg);
		}
	}
}