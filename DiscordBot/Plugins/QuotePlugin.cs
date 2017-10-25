using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSharpPlus;
using DSharpPlus.EventArgs;

namespace DiscordBot.Plugins {
	class QuotePlugin : DiscordPlugin {
		private const string QUOTE_USAGE = "Quote Command Usage\n!quote add <author>;<message>\n!quote get <author>\n!quote remove <author>\n!quote clear";
		private List<DiscordServerData> m_discordServers = new List<DiscordServerData>();

		public QuotePlugin(DiscordClient a_discordClient) : base(a_discordClient) {
			Command = "!quote";
		}

		public override async Task OnMessageCreated(MessageCreateEventArgs e) {
			string[] splitString = e.Message.Content.Split(' ');

			if (splitString[0] != Command) {
				return;
			}

			for (int i = 0; i < splitString.Length; ++i) {
				splitString[i] = splitString[i].Trim();
			}

			DiscordServerData ds = m_discordServers.Find(x => x.Guild == e.Guild);

			if (ds == null) {
				ds = new DiscordServerData(e.Guild);
				m_discordServers.Add(ds);
			}

			if (e.Message.Content.Trim() == Command) {
				await e.Message.RespondAsync(ds.GetRandomQuote(""));
				return;
			}

			string subCommand = splitString[1];

			if (subCommand == "get") {
				await e.Message.RespondAsync(ds.GetRandomQuote(e.Message.Content.Substring(Command.Length + subCommand.Length + 1).Trim()));
				return;
			} else if (subCommand == "add") {
				await e.Message.RespondAsync(ds.AddQuote(e.Message.Content.Substring(Command.Length + subCommand.Length + 1).Trim()));
				return;
			} else if (subCommand == "remove") {
				await e.Message.RespondAsync(ds.RemoveQuotesForUser(e.Message.Content.Substring(Command.Length + subCommand.Length + 1).Trim()));
				return;
			} else if (subCommand == "clear") {
				var discordMember = e.Guild.Members.First(x => x.Id == e.Author.Id);

				if (discordMember != null) {
					await e.Message.RespondAsync(ds.ClearQuotes(discordMember));
				}

				return;
			} else if (subCommand == "count") {
				await e.Message.RespondAsync(ds.GetQuoteCount());
				return;
			} else if (subCommand == "help") {
				await e.Message.RespondAsync(QUOTE_USAGE);
				return;
			}
			await e.Message.RespondAsync(ds.GetRandomQuote(e.Message.Content.Substring(Command.Length + subCommand.Length + 1).Trim()));
		}
	}
}
