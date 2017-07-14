using MonoMac.AppKit;
using TinyMessenger;

namespace Actionix {
	public class ApplicationCommandContext : ICommandContext {
		public object Target { get; set; }
		public string BundleName { get; set; }
	}

	public class ApplicationCommandExecutor : IApplicationCommandExecutor {
		public ApplicationCommandExecutor(ITinyMessengerHub hub) {
		}

		public void Execute(ICommandContext context) {
			var ctx = context as ApplicationCommandContext;

			if (ctx != null) {
				Execute(ctx.BundleName);
			}
		}

		public void Execute(string context) {
			NSWorkspace.SharedWorkspace.LaunchApplication(context);
		}
	}
}