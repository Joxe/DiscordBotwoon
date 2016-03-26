using System.Text;
using DiscordSharp.Events;

namespace DiscordBot.Plugins {
	class CommandsPlugin : DiscordPlugin {
		private const string COMMANDS = "Available Commands";

		public CommandsPlugin(DiscordMain a_discordMain) : base(a_discordMain) {
			Command = "!commands";
		}

		public override void onMessageReceived(object a_sender, DiscordMessageEventArgs a_eventArgs) {
			if (a_eventArgs.message_text.Split(' ')[0].Trim() != Command) {
				return;
			}

			StringBuilder commands = new StringBuilder();

			commands.AppendLine(COMMANDS);

			foreach (var plugin in m_discordMain.Plugins) {
				commands.AppendLine(plugin.Command);
			}

			a_eventArgs.Channel.SendMessage(commands.ToString());
		}

		public override string ToString() {
			return "Commands Plugin";
		}
	}
}
