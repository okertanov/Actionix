using System;
using System.Collections.Generic;
using System.Drawing;
using MonoMac.AppKit;
using MonoMac.Foundation;
using MonoMac.ObjCRuntime;
using Actionix.Core;

namespace Actionix.MenuBuilders {
	//
	// Chrome tabs menu items
	//
	public class ChromeTabsMenuItemsBuilder : IMenuItemsBuilder {
		private const string chromeTabsTitle = "Chrome Tabs";
		private readonly Bindings.ChromeScripting chromeScripting;
		private List<string> tabs;

		public ChromeTabsMenuItemsBuilder() {
			chromeScripting = new Bindings.ChromeScripting(@"com.google.Chrome");
			tabs = new List<string>();
		}

		public void AttachTo(NSMenu menu) {
			var tabsMenuItem = new NSMenuItem(chromeTabsTitle, "", OnMenu);
			tabsMenuItem.Submenu = new NSMenu(chromeTabsTitle) {
				WeakDelegate = new ChromeTabsMenuDelegate(this)
			};
			menu.AddItem(tabsMenuItem);

			chromeScripting.Activate();
		}

		private void OnMenu(object sender, EventArgs args) {
			var menuItem = sender as NSMenuItem;
			if (menuItem != null) {
				
			}
		}

		private void UpdateTabs(object sender) {
			//var tabsNumber = chromeScripting.GetTabsNumber();
		}

		private int GetTabsNumber(object sender) {
			var tabsNumber = tabs.Count;
			return tabsNumber;
		}

		internal class ChromeTabsMenuDelegate : NSMenuDelegate {
			private readonly WeakReferenceEx<ChromeTabsMenuItemsBuilder> parentRef;

			public ChromeTabsMenuDelegate(ChromeTabsMenuItemsBuilder parent) {
				parentRef = WeakReferenceEx.Create(parent);
			}

			public override void MenuWillOpen(NSMenu menu) {
				Console.WriteLine(String.Format("MenuWillOpen: for menu: {0}", menu.Title));
			}

			public override void MenuDidClose(NSMenu menu) {
				Console.WriteLine(String.Format("MenuDidClose: for menu: {0}", menu.Title));
			}

			public override int MenuItemCount(NSMenu menu) {
				Console.WriteLine(String.Format("MenuItemCount: for menu: {0}", menu.Title));
				return parentRef.Target.GetTabsNumber(this);
			}

			public override void MenuWillHighlightItem(NSMenu menu, NSMenuItem item) {
				Console.WriteLine(String.Format("MenuWillHighlightItem: for menu: {0}, item: {1}", menu.Title, item.Title));
			}

			public override void NeedsUpdate(NSMenu menu) {
				Console.WriteLine(String.Format("NeedsUpdate: for menu: {0}", menu.Title));
			}

			public override bool UpdateItem(NSMenu menu, NSMenuItem item, int atIndex, bool shouldCancel) {
				Console.WriteLine(String.Format("UpdateItem: for menu: {0}, item: {1}, atIndex: {2}, shouldCancel: {3}", menu.Title, item.Title, atIndex, shouldCancel));
				return base.UpdateItem(menu, item, atIndex, shouldCancel);
			}

			public override RectangleF ConfinementRectForMenu(NSMenu menu, NSScreen screen) {
				Console.WriteLine(String.Format("ConfinementRectForMenu: for menu: {0}, screen: {1}", menu.Title, screen.DeviceDescription));
				return base.ConfinementRectForMenu(menu, screen);
			}

			public override bool HasKeyEquivalentForEvent(NSMenu menu, NSEvent theEvent, NSObject target, Selector action) {
				Console.WriteLine(String.Format("HasKeyEquivalentForEvent: for menu: {0}, event: {1}, target: {2}", menu.Title, theEvent, target));
				return base.HasKeyEquivalentForEvent(menu, theEvent, target, action);
			}
		}
	}
}