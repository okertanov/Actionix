using TinyMessenger;

namespace Actionix.Messages {
	public class AppBeforeExitMessage : GenericTinyMessage<object> {
		public AppBeforeExitMessage(object sender, object payload) : base(sender, payload) {
		}
	}
}