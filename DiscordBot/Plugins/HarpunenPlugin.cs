using System;
using System.Threading.Tasks;
using DSharpPlus;
using DSharpPlus.EventArgs;

namespace DiscordBot.Plugins {
	class HarpunenPlugin : DiscordPlugin {
		public HarpunenPlugin(DiscordClient a_discordMain) : base(a_discordMain) {
			Command = "!harpunen";
			Console.WriteLine("\tHarpunen Plugin Loaded, command: " + Command);
		}

		public override async Task OnMessageCreated(MessageCreateEventArgs e) {
			if (e.Message.Content.Split(' ')[0].Trim() != Command) {
				return;
			}

			await e.Message.RespondAsync("https://www.youtube.com/watch?v=93Tj2bCslBk");
			return;
		}

		public override string ToString() {
			return "Harpunen Plugin";
		}
	}
}
