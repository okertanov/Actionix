using System;
using MonoMac.Foundation;
using MonoMac.ObjCRuntime;

namespace Actionix.Bindings {
	[BaseType(typeof (NSObject))]
	public interface ChromeScripting {
		[Export ("initWithBundleName:")]
		IntPtr Constructor (string bName);

		[Export ("activate")]
		void Activate ();

		[Export ("openTab:")]
		void OpenTab (string url);
	}
}
