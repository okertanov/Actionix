using MonoMac.AppKit;
using MonoMac.Foundation;

namespace Actionix
{
	[Register ("ActionixAppDelegate")]
	public class ActionixAppDelegate : NSApplicationDelegate
	{
		public ActionixAppDelegate() : base()
		{
		}

		public override void FinishedLaunching(NSObject notification)
		{
			Bootstrapper.Register();
			Bootstrapper.Bootstrap();
		}
	}
}

