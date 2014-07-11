using System;
using TinyMessenger;

namespace Actionix
{
	//
	// Menu extra main module
	//
	public class MenuExtraModule : IMenuExtraModule
	{
		private SystemStatusBarItem _systemStatusBarItem;
		private GlobalShortcutKeyMonitor _globalShortcutKeyMonitor;
		private readonly ITinyMessengerHub _hub;
		private TinyMessageSubscriptionToken _appBeforeExitMessageToken;

		public MenuExtraModule(ITinyMessengerHub hub)
		{
			_hub = hub;

			//
			// Status bar menu
			//
			var _systemStatusBarItem = new SystemStatusBarItem();

			var iconMenuVisualizer = new IconMenuVisualizer();
			_systemStatusBarItem.AssignMenuVisualizer(iconMenuVisualizer);

			var menuBuilder = new MenuBuilder(SharedSettings.AppName, new IMenuItemsBuilder[] {
				new NewObjectMenuItemsBuilder(),
				new SeparatorMenuItemsBuilder(),
				new StaticMenuItemsBuilder(),
				new SeparatorMenuItemsBuilder(),
				new AppMenuItemsBuilder()
			});
			_systemStatusBarItem.AssignMenuBuilder(menuBuilder);

			//
			// Global Shortcut Key Handler
			//
			// System Preferences > Security & Privacy > Privacy > Accessibility
			//
			_globalShortcutKeyMonitor = new GlobalShortcutKeyMonitor((ev) => {
				_systemStatusBarItem.ShowMenuAt(ev.LocationInWindow);
			});

			//
			// Events subscription
			//
			_appBeforeExitMessageToken = _hub.Subscribe<AppBeforeExitMessage>(m => {
				Cleanup();
			});

			//
			// Periodic ticker
			// See https://developer.apple.com/library/mac/documentation/Cocoa/Reference/ApplicationKit/Classes/NSEvent_Class/Reference/Reference.html
			// NSEvent.StartPeriodicEventsAfterDelay
			//

			/*var alert = new NSAlert();
			alert.MessageText = "Hi!";
			alert.InformativeText = "...";
			alert.RunModal();*/
		}

		public void Run()
		{
		}

		public void Dispose()
		{
			Cleanup();
		}

		private void Cleanup()
		{
			if (_appBeforeExitMessageToken != null) {
				_hub.Unsubscribe<AppBeforeExitMessage>(_appBeforeExitMessageToken);
				_appBeforeExitMessageToken = null;
			}

			if (_globalShortcutKeyMonitor != null) {
				_globalShortcutKeyMonitor.Dispose();
				_globalShortcutKeyMonitor = null;
			}
		}
	}
}

