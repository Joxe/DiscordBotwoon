using System.Text;
using System.Threading.Tasks;
using DSharpPlus;
using DSharpPlus.EventArgs;

namespace DiscordBot.Plugins {
	class CommandsPlugin : DiscordPlugin {
		private const string COMMANDS = "Available Commands";

		public CommandsPlugin(DiscordClient a_discordClient) : base(a_discordClient) {
			Command = "!commands";
		}

		public override async Task OnMessageCreated(MessageCreateEventArgs e) {
			if (e.Message.Content.Split(' ')[0].Trim() != Command) {
				return;
			}

			StringBuilder commands = new StringBuilder();

			commands.AppendLine(COMMANDS);

			foreach (var plugin in DiscordMain.Plugins) {
				commands.AppendLine(plugin.Command);
			}

			await e.Message.RespondAsync(commands.ToString());
		}

		public override string ToString() {
			return "Commands Plugin";
		}
	}
}
