using System;

namespace Actionix.Core {
	public static class WeakReferenceEx {
		public static WeakReferenceEx<T> Create<T>(T target) where T: class {
			return new WeakReferenceEx<T>(target);
		}
	}

	public class WeakReferenceEx<T> where T:class {
		private readonly WeakReference<T> weakReference;

		public WeakReferenceEx(T obj) {
			weakReference = new WeakReference<T>(obj);
		}

		public T Target {
			get {
				T target;
				if(weakReference.TryGetTarget(out target)) {
					return target;
				}

				return null;
			}
		}
	}
}