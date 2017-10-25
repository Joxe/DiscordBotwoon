using System.Threading.Tasks;
using DSharpPlus;
using DSharpPlus.EventArgs;

namespace DiscordBot.Plugins {
	class DamageBoostPlugin : DiscordPlugin {
		public DamageBoostPlugin(DiscordClient a_discordClient) : base(a_discordClient) {
			Command = "!dboost";
		}

		public override async Task OnMessageCreated(MessageCreateEventArgs e) {
			if (e.Message.Content.Split(' ')[0].Trim() != Command) {
				return;
			}

			await e.Message.RespondAsync("http://i.imgur.com/cSAlF1d.jpg");
		}

		public override string ToString() {
			return "Damage Boost Plugin";
		}
	}
}
