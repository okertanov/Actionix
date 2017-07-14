using MonoMac.AppKit;
using System.Drawing;
using TinyMessenger;
using Actionix.App;
using Actionix.Messages;

namespace Actionix.Menu {
	public class SystemStatusBarItem : ISystemStatusBarItem {
		private readonly NSStatusItem _systemStatusBarItem;

		private readonly ITinyMessengerHub _hub;
		private TinyMessageSubscriptionToken _showMenuMessageToken;
		private TinyMessageSubscriptionToken _periodicEventMessageToken;

		public SystemStatusBarItem(ITinyMessengerHub hub) {
			_hub = hub;

			_systemStatusBarItem = NSStatusBar.SystemStatusBar.CreateStatusItem(SharedSettings.StatusBarIconSize.Width);

			_showMenuMessageToken = _hub.Subscribe<ShowMenuMessage>(ShowMenuMessageHandler);
			_periodicEventMessageToken = _hub.Subscribe<PeriodicEventMessage>(PeriodicEventMessageHandler);
		}

		public void AssignMenuBuilder(IMenuBuilder menuBuilder) {
			_systemStatusBarItem.Menu = menuBuilder.Build();
		}

		public void AssignMenuVisualizer(IMenuVisualizer menuVisualizer) {
			menuVisualizer.AttachTo(_systemStatusBarItem);
		}

		private void ShowMenuAt(PointF pointAt) {
			_systemStatusBarItem.Menu.PopUpMenu(_systemStatusBarItem.Menu.ItemAt(0), pointAt, null);
		}

		private void UpdateMenu() {
		}

		private void ShowMenuMessageHandler(ShowMenuMessage msg) {
			NSApplication.SharedApplication.InvokeOnMainThread(() => {
				ShowMenuAt(msg.Content.LocationInWindow);
			});
		}

		void PeriodicEventMessageHandler(PeriodicEventMessage msg) {
			NSApplication.SharedApplication.InvokeOnMainThread(() => {
				UpdateMenu();
			});
		}

		public void Dispose() {
			NSStatusBar.SystemStatusBar.RemoveStatusItem(_systemStatusBarItem);

			if (_showMenuMessageToken != null) {
				_hub.Unsubscribe<ShowMenuMessage>(_showMenuMessageToken);
				_showMenuMessageToken = null;
			}

			if (_periodicEventMessageToken != null) {
				_hub.Unsubscribe<PeriodicEventMessage>(_periodicEventMessageToken);
				_periodicEventMessageToken = null;
			}
		}
	}
}