using System.Threading.Tasks;
using DSharpPlus;
using DSharpPlus.EventArgs;

namespace DiscordBot.Plugins {
	class VersionPlugin : DiscordPlugin {
		private const string VERSION = "Hello I'm Botwoon in a very early version (25th of October 2017), please no Super Missiles.";

		public VersionPlugin(DiscordClient a_discordClient) : base(a_discordClient) {
			Command = "!version";
		}

		public override async Task OnMessageCreated(MessageCreateEventArgs e) {
			if (e.Message.Content.Split(' ')[0].Trim() != Command) {
				return;
			}

			await e.Message.RespondAsync(VERSION);
		}

		public override string ToString() {
			return "Version Plugin";
		}
	}
}
