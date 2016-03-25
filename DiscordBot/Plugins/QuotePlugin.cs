using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiscordSharp.Events;

namespace DiscordBot.Plugins {
	class QuotePlugin : DiscordPlugin {
		private const string QUOTE_USAGE = "Quote Command Usage\n!quote add <author>;<message>\n!quote get\n!quote get <author>\n!quote remove <author>\n!quote clear";
		private List<DiscordServerData> m_discordServers = new List<DiscordServerData>();

		public QuotePlugin(DiscordMain a_discordMain) : base(a_discordMain) {
			Command = "!quote";
		}

		public override void onMessageReceived(object a_sender, DiscordMessageEventArgs a_eventArgs) {
			string[] splitString = a_eventArgs.message_text.Split(' ');


			if (splitString[0] != Command) {
				return;
			}

			for (int i = 0; i < splitString.Length; ++i) {
				splitString[i] = splitString[i].Trim();
			}

			if (a_eventArgs.message_text.Length == Command.Length) {
				a_eventArgs.Channel.SendMessage(QUOTE_USAGE);
				return;
			}

			DiscordServerData ds = m_discordServers.Find(x => x.Server == a_eventArgs.Channel.parent);

			if (ds == null) {
				ds = new DiscordServerData(a_eventArgs.Channel.parent);
				m_discordServers.Add(ds);
			}

			string subCommand = splitString[1];

			if (subCommand == "get") {
				a_eventArgs.Channel.SendMessage(ds.getRandomQuote(a_eventArgs.message_text.Substring(Command.Length + subCommand.Length + 1).Trim()));
				return;
			} else if (subCommand == "add") {
				a_eventArgs.Channel.SendMessage(ds.addQuote(a_eventArgs.message_text.Substring(Command.Length + subCommand.Length + 1).Trim()));
				return;
			} else if (subCommand == "remove") {
				a_eventArgs.Channel.SendMessage(ds.removeQuotesForUser(a_eventArgs.message_text.Substring(Command.Length + subCommand.Length + 1).Trim()));
				return;
			} else if (subCommand == "clear") {
				a_eventArgs.Channel.SendMessage(ds.clearQuotes(a_eventArgs.author));
				return;
			} else if (subCommand == "count") {
				a_eventArgs.Channel.SendMessage(ds.getQuoteCount());
				return;
			}
			a_eventArgs.Channel.SendMessage(QUOTE_USAGE);
		}
	}
}
