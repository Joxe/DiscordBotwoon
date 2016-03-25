using DiscordSharp.Events;

namespace DiscordBot.Plugins {
	class PenisPlugin : DiscordPlugin {
		public PenisPlugin(DiscordMain a_discordMain) : base(a_discordMain) {
			Command = "!penis";
		}

		public override void onMessageReceived(object a_sender, DiscordMessageEventArgs a_eventArgs) {
			if (a_eventArgs.message_text.Split(' ')[0].Trim() != Command) {
				return;
			}

			a_eventArgs.Channel.SendMessage("https://www.youtube.com/watch?v=1qe2MDdfw1g");
		}

		public override string ToString() {
			return "En man som älskar [penis] Plugin";
		}
	}
}
