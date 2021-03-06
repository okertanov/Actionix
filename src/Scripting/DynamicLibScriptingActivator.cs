﻿using System;
using MonoMac.ObjCRuntime;
using MonoMac.Foundation;

namespace Actionix.Scripting {
	public class DynamicLibScriptingActivator : IDisposable {
		private IntPtr _handle;
		private string _dlPath;

		private const string ContentsMonoBundlePath = "Contents/MonoBundle";
		private readonly string BundleLibPath;

		public DynamicLibScriptingActivator(string dlName) {
			BundleLibPath = System.IO.Path.Combine(NSBundle.MainBundle.BundlePath, ContentsMonoBundlePath);

			_dlPath = System.IO.Path.Combine(BundleLibPath, dlName);

			Activate();
		}

		private void Activate() {
			_handle = Dlfcn.dlopen(_dlPath, 0);
			if (_handle == IntPtr.Zero) {
				throw new DynamicLibScriptingException(String.Format("Unable to load the dynamic library: {0}", _dlPath));
			}
		}

		private void Deactivate() {
			if (_handle != IntPtr.Zero) {
				Dlfcn.dlclose(_handle);
				_handle = IntPtr.Zero;
			}
		}

		public void Dispose() {
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool disposing) {
			Deactivate();
		}

		~DynamicLibScriptingActivator() {
			Dispose(false);
		}
	}
}