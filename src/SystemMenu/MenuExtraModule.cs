using System;
using TinyMessenger;
using MonoMac.AppKit;

namespace Actionix
{
	//
	// Menu extra main module
	//
	public class MenuExtraModule : IMenuExtraModule
	{
		private SystemStatusBarItem _systemStatusBarItem;
		private GlobalShortcutKeyMonitor _globalShortcutKeyMonitor;
		private PeriodicEventMonitor _periodicEventMonitor;
		private readonly ITinyMessengerHub _hub;
		private TinyMessageSubscriptionToken _appBeforeExitMessageToken;

		public MenuExtraModule(ITinyMessengerHub hub)
		{
			_hub = hub;

			//
			// Status bar menu
			//
			var _systemStatusBarItem = new SystemStatusBarItem(hub);

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
				var msg = new ShowMenuMessage(NSApplication.SharedApplication, ev);
				hub.PublishAsync(msg);
			});

			//
			// Periodic Events Handler
			//
			_periodicEventMonitor = new PeriodicEventMonitor((ev) => {
				var msg = new PeriodicEventMessage(NSApplication.SharedApplication, ev);
				hub.PublishAsync(msg);
			});

			//
			// Module events subscription
			//
			_appBeforeExitMessageToken = _hub.Subscribe<AppBeforeExitMessage>(m => {
				_systemStatusBarItem.Dispose();
				_systemStatusBarItem = null;

				Cleanup();
			});
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
			if (_appBeforeExitMessageToken != null)
			{
				_hub.Unsubscribe<AppBeforeExitMessage>(_appBeforeExitMessageToken);
				_appBeforeExitMessageToken = null;
			}

			if (_systemStatusBarItem != null)
			{
				_systemStatusBarItem.Dispose();
				_systemStatusBarItem = null;
			}

			if (_globalShortcutKeyMonitor != null)
			{
				_globalShortcutKeyMonitor.Dispose();
				_globalShortcutKeyMonitor = null;
			}

			if (_periodicEventMonitor != null)
			{
				_periodicEventMonitor.Dispose();
				_periodicEventMonitor = null;
			}
		}
	}
}

