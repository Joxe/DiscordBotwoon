using DiscordSharp;
using DiscordSharp.Objects;
using System;
using System.Linq;

namespace DiscordBot {
	public class MessageSearch : Command {

		private const string USAGE = "Find Command Usage\n!find <text>";
		private const string RESPONSE_NO_MESSAGE_FOUND = "None of the last {0} messages contains the string \"{1}\".";
		private const string RESPONSE_MESSAGE_FOUND = "At {0}, {1} said: {2}";
		private const int PAGE_SIZE = 64;
		private const int MAX_PAGES = 8;
		private const int MAX_MESSAGES = PAGE_SIZE * MAX_PAGES;

		public void execute(DiscordClient client, DiscordChannel channel, DiscordMember user, string stringToFind) {
			if (string.IsNullOrEmpty(stringToFind)) {
				client.SendMessageToChannel(USAGE, channel);
			} else {
				var iterator = MessageHistoryIterator.flatten(PAGE_SIZE, MAX_PAGES, client, channel);
				var foundMessage = iterator.FirstOrDefault(x => x.content.Contains(stringToFind));
				client.SendMessageToChannel(
					foundMessage == null
						? ResponseNoMessageFound(stringToFind)
						: ResponseMessageFound(foundMessage)
					,
					channel
				);
			}
		}
		
		private static string ResponseNoMessageFound(string stringToFind) {
			return string.Format(RESPONSE_NO_MESSAGE_FOUND, MAX_MESSAGES, stringToFind);
		}

		private static string ResponseMessageFound(DiscordMessage message) {
			return string.Format(RESPONSE_MESSAGE_FOUND, message.timestamp.ToString(), message.author.Username, message.content);
		}
	}
}

