using DiscordSharp.Events;

namespace DiscordBot.Plugins {
	class DamageBoostPlugin : DiscordPlugin {
		public DamageBoostPlugin(DiscordMain a_discordMain) : base(a_discordMain) {
			Command = "!dboost";
		}

		public override void onMessageReceived(object a_sender, DiscordMessageEventArgs a_eventArgs) {
			if (a_eventArgs.message_text.Split(' ')[0].Trim() != Command) {
				return;
			}

			a_eventArgs.Channel.SendMessage("http://i.imgur.com/cSAlF1d.jpg");
		}

		public override string ToString() {
			return "Damage Boost Plugin";
		}
	}
}
