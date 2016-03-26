using DiscordSharp.Events;

namespace DiscordBot.Plugins {
	class VersionPlugin : DiscordPlugin {
		private const string VERSION = "Hello I'm Botwoon in a very early version (25th of March 2016), please no Super Missiles.";

		public VersionPlugin(DiscordMain a_discordMain) : base(a_discordMain) {
			Command = "!version";
		}

		public override void onMessageReceived(object a_sender, DiscordMessageEventArgs a_eventArgs) {
			if (a_eventArgs.message_text.Split(' ')[0].Trim() != Command) {
				return;
			}

			a_eventArgs.Channel.SendMessage(VERSION);
		}

		public override string ToString() {
			return "Version Plugin";
		}
	}
}
