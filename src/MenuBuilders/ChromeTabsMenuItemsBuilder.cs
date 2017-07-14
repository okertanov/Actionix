using System;
using System.Drawing;
using MonoMac.AppKit;
using MonoMac.Foundation;
using MonoMac.ObjCRuntime;

namespace Actionix {
	//
	// Chrome tabs menu items
	//
	public class ChromeTabsMenuItemsBuilder : IMenuItemsBuilder {
		private const string chromeTabsTitle = "Chrome Tabs";

		public void AttachTo(NSMenu menu) {
			var tabsMenuItem = new NSMenuItem(chromeTabsTitle, "", OnMenu);
			tabsMenuItem.Submenu = new NSMenu(chromeTabsTitle) {
				WeakDelegate = new ChromeTabsMenuDelegate()
			};
			menu.AddItem(tabsMenuItem);
		}

		private void OnMenu(object sender, EventArgs args) {
		}

		internal class ChromeTabsMenuDelegate : NSMenuDelegate {
			public override void MenuWillOpen(NSMenu menu) {
			}

			public override void MenuDidClose(NSMenu menu) {
			}

			public override int MenuItemCount(NSMenu menu) {
				return 3;
			}

			public override void MenuWillHighlightItem(NSMenu menu, NSMenuItem item) {
			}

			public override void NeedsUpdate(NSMenu menu) {
			}

			public override bool UpdateItem(NSMenu menu, NSMenuItem item, int atIndex, bool shouldCancel) {
				return base.UpdateItem(menu, item, atIndex, shouldCancel);
			}

			public override RectangleF ConfinementRectForMenu(NSMenu menu, NSScreen screen) {
				return base.ConfinementRectForMenu(menu, screen);
			}

			public override bool HasKeyEquivalentForEvent(NSMenu menu, NSEvent theEvent, NSObject target, Selector action) {
				return base.HasKeyEquivalentForEvent(menu, theEvent, target, action);
			}
		}
	}
}