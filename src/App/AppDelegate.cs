﻿using MonoMac.AppKit;
using MonoMac.Foundation;

namespace Actionix.App {
	[Register("ActionixAppDelegate")]
	public class ActionixAppDelegate : NSApplicationDelegate {
		public ActionixAppDelegate() {
			Bootstrapper.Register();
		}

		public override void FinishedLaunching(NSObject notification) {
			Bootstrapper.Bootstrap();
		}

		public override void WillTerminate(NSNotification notification) {
			Bootstrapper.Terminate();
		}
	}
}