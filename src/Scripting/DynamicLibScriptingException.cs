using System;

namespace Actionix.Scripting {
	public class DynamicLibScriptingException : Exception {
		public DynamicLibScriptingException() : base() { }
		public DynamicLibScriptingException(string what) : base(what) { }
		public DynamicLibScriptingException(string what, Exception inner) : base(what, inner) { }
	}
}