using DiscordSharp;
using DiscordSharp.Objects;
using System;

namespace DiscordBot {
	public class ConstantReply : Command {

		public readonly string message;

		public ConstantReply(string a_message) {
			if (a_message == null)
				throw new ArgumentNullException(a_message);
			message = a_message;
		}

		public void execute(DiscordClient client, DiscordChannel channel, DiscordMember user, string parameters) {
			client.SendMessageToChannel(string.Format(message, user, parameters), channel);
		}		
	}
}

