using System.Threading.Tasks;
using DSharpPlus;
using DSharpPlus.EventArgs;

namespace DiscordBot.Plugins {
	class PenisPlugin : DiscordPlugin {
		public PenisPlugin(DiscordClient a_discordMain) : base(a_discordMain) {
			Command = "!penis";
		}

		public override async Task OnMessageCreated(MessageCreateEventArgs e) {
			if (e.Message.Content.Split(' ')[0].Trim() != Command) {
				return;
			}

			await e.Message.RespondAsync("https://www.youtube.com/watch?v=1qe2MDdfw1g");
		}

		public override string ToString() {
			return "En man som älskar [penis] Plugin";
		}
	}
}
