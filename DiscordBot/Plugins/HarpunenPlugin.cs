using DiscordSharp.Events;

namespace DiscordBot.Plugins {
	class HarpunenPlugin : DiscordPlugin {
		public HarpunenPlugin(DiscordMain a_discordMain) : base(a_discordMain) {
			Command = "!harpunen";
		}

		public override void onMessageReceived(object a_sender, DiscordMessageEventArgs a_eventArgs) {
			if (a_eventArgs.message_text.Split(' ')[0].Trim() != Command) {
				return;
			}

			a_eventArgs.Channel.SendMessage("https://www.youtube.com/watch?v=93Tj2bCslBk");
		}

		public override string ToString() {
			return "Harpunen Plugin";
		}
	}
}
