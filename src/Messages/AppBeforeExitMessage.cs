using System;
using TinyMessenger;

namespace Actionix
{
	public class AppBeforeExitMessage : GenericTinyMessage<object>
	{
		public AppBeforeExitMessage(object sender, object payload) : base(sender, payload)
		{
		}
	}
}

