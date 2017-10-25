/*
using DiscordSharp;
using DiscordSharp.Events;
using DiscordSharp.Objects;
using System.Linq;

namespace DiscordBot.Plugins {
	class MessageFindPlugin : DiscordPlugin {

		private const string USAGE = "Find Command Usage\n!find <text>";
		private const string RESPONSE_NO_MESSAGE_FOUND = "None of the last {0} messages contains the string \"{1}\".";
		private const string RESPONSE_MESSAGE_FOUND = "At {0}, {1} said: {2}";
		private const int PAGE_SIZE = 64;
		private const int MAX_PAGES = 8;
		private const int MAX_MESSAGES = PAGE_SIZE * MAX_PAGES;

		public MessageFindPlugin(DiscordMain a_discordMain) : base(a_discordMain) {
			Command = "!find";
		}

		public override void onMessageReceived(object a_sender, DiscordMessageEventArgs a_eventArgs) {
			if (!a_eventArgs.message_text.StartsWith(Command)) {
				return;
			}
			DiscordChannel channel = a_eventArgs.Channel;
			string stringToFind = a_eventArgs.message_text.Substring(Command.Length).Trim();
			if (string.IsNullOrEmpty(stringToFind)) {
				channel.SendMessage(USAGE);
			} else {
				stringToFind = removeEncapsulation(stringToFind, "\"").ToLower();
				var iterator = MessageHistoryIterator.flatten(PAGE_SIZE, MAX_PAGES, m_discordMain.Client, channel);
				var foundMessage = iterator.FirstOrDefault(x => MessageMatchesSearch(x, stringToFind));
				channel.SendMessage(foundMessage == null
					? ResponseNoMessageFound(stringToFind)
					: ResponseMessageFound(foundMessage)
				);
			}
		}

		public override string ToString() {
			return "Message Find Plugin";
		}

		private static string ResponseNoMessageFound(string stringToFind) {
			return string.Format(RESPONSE_NO_MESSAGE_FOUND, MAX_MESSAGES, stringToFind);
		}

		private static string ResponseMessageFound(DiscordMessage message) {
			return string.Format(RESPONSE_MESSAGE_FOUND, message.timestamp.ToString(), message.author.Username, message.content);
		}

		private static string removeEncapsulation(string str, string encapsulation) {
			return str.StartsWith(encapsulation) && str.EndsWith(encapsulation)
				? str.Substring(encapsulation.Length, str.Length - (encapsulation.Length * 2))
				: str;
		}

		private static bool MessageMatchesSearch(DiscordMessage message, string searchString) {
			return message.content.ToLower().Contains(searchString);
		}
	}
}
*/
