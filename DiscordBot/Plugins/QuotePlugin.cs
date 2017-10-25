/*
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiscordSharp.Events;

namespace DiscordBot.Plugins {
	class QuotePlugin : DiscordPlugin {
		private const string QUOTE_USAGE = "Quote Command Usage\n!quote add <author>;<message>\n!quote get <author>\n!quote remove <author>\n!quote clear";
		private List<DiscordServerData> m_discordServers = new List<DiscordServerData>();

		public QuotePlugin(DiscordMain a_discordMain) : base(a_discordMain) {
			Command = "!quote";
		}

		public override void onMessageReceived(object a_sender, DiscordMessageEventArgs a_eventArgs) {
			string[] splitString = a_eventArgs.MessageText.Split(' ');

			if (splitString[0] != Command) {
				return;
			}

			for (int i = 0; i < splitString.Length; ++i) {
				splitString[i] = splitString[i].Trim();
			}

			DiscordServerData ds = m_discordServers.Find(x => x.Server == a_eventArgs.Channel.Parent);

			if (ds == null) {
				ds = new DiscordServerData(a_eventArgs.Channel.Parent);
				m_discordServers.Add(ds);
			}

			if (a_eventArgs.MessageText.Length == Command.Length) {
				a_eventArgs.Channel.SendMessage(ds.getRandomQuote(""));
				return;
			}

			string subCommand = splitString[1];

			if (subCommand == "get") {
				a_eventArgs.Channel.SendMessage(ds.getRandomQuote(a_eventArgs.MessageText.Substring(Command.Length + subCommand.Length + 1).Trim()));
				return;
			} else if (subCommand == "add") {
				a_eventArgs.Channel.SendMessage(ds.addQuote(a_eventArgs.MessageText.Substring(Command.Length + subCommand.Length + 1).Trim()));
				return;
			} else if (subCommand == "remove") {
				a_eventArgs.Channel.SendMessage(ds.removeQuotesForUser(a_eventArgs.MessageText.Substring(Command.Length + subCommand.Length + 1).Trim()));
				return;
			} else if (subCommand == "clear") {
				a_eventArgs.Channel.SendMessage(ds.clearQuotes(a_eventArgs.Author));
				return;
			} else if (subCommand == "count") {
				a_eventArgs.Channel.SendMessage(ds.getQuoteCount());
				return;
			} else if (subCommand == "help") {
				a_eventArgs.Channel.SendMessage(QUOTE_USAGE);
				return;
			}
			a_eventArgs.Channel.SendMessage(ds.getRandomQuote(a_eventArgs.MessageText.Substring(Command.Length + subCommand.Length + 1).Trim()));
		}
	}
}

*/