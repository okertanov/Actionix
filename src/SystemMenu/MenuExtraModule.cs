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
		private ISystemStatusBarItem _systemStatusBarItem;
		private IGlobalShortcutKeyMonitor _globalShortcutKeyMonitor;
		private IPeriodicEventMonitor _periodicEventMonitor;
		private readonly ITinyMessengerHub _hub;
		private TinyMessageSubscriptionToken _appBeforeExitMessageToken;

		public MenuExtraModule(ITinyMessengerHub hub, ISystemStatusBarItem systemStatusBarItem, IGlobalShortcutKeyMonitor globalShortcutKeyMonitor, IPeriodicEventMonitor periodicEventMonitor)
		{
			_hub = hub;
			_globalShortcutKeyMonitor = globalShortcutKeyMonitor;
			_periodicEventMonitor = periodicEventMonitor;
			_systemStatusBarItem = systemStatusBarItem;

			//
			// Init Status bar menu
			//
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
			_globalShortcutKeyMonitor.Activate((ev) => {
				var msg = new ShowMenuMessage(NSApplication.SharedApplication, ev);
				hub.PublishAsync(msg);
			});

			//
			// Periodic Events Handler
			//
			_periodicEventMonitor.Activate((ev) => {
				var msg = new PeriodicEventMessage(NSApplication.SharedApplication, ev);
				hub.PublishAsync(msg);
			});

			//
			// Module events subscription
			//
			_appBeforeExitMessageToken = _hub.Subscribe<AppBeforeExitMessage>(m => {
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

