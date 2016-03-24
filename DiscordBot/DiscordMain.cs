using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using DiscordSharp;
using DiscordSharp.Events;
using DiscordSharp.Objects;

namespace DiscordBot {
	class DiscordMain {
		private const string VERSION = "Hello I'm Botwoon in a very early version (24th of March 2016), please no Super Missiles.";
		private const string COMMANDS = "Available Commands\n!time\n!harpunen\n!penis\n!dboost\n!quote\n!d2r";
		private const string QUOTE_USAGE = "Quote Command Usage\n!quote add <author>;<message>\n!quote get\n!quote get <author>\n!quote remove <author>\n!quote clear";
		private const string D2_USAGE = "Diablo 2 Command Usage\n!d2r <runeword name>\n!d2r find <itemtype> <sockets>\n!d2r find <runes>";
		private const string EMSG_D2_CANT_FIND_SOCKETS = "I can't understand how many sockets the item you specified has!";
		private const string EMSG_D2_NO_ITEM = "You have no specified an item to look for!";

		private DiscordClient client = new DiscordClient();
		private List<DiscordServerData> m_discordServers = new List<DiscordServerData>();

		public DiscordMain() {
			if (!File.Exists("credentials.txt")) {
				throw new FileNotFoundException("No 'credentials.txt' found, make sure that it's placed in the same directory as the executable!");
			}

			using (StreamReader sr = new StreamReader("credentials.txt")) {
				client.ClientPrivateInformation.email = sr.ReadLine();
				client.ClientPrivateInformation.password = sr.ReadLine();
			}

			client.Connected += (sender, e) => {  Console.WriteLine($"Connected! User: {e.user.Username }"); };
			client.SendLoginRequest();
			client.MessageReceived += parseMessage;
			client.Connected += onConnected;

			Thread t = new Thread(client.Connect);
			t.Start();

			while (true) {
				Thread.Sleep(100);
			}
		}

		private void onConnected(object a_sender, DiscordConnectEventArgs a_eventArgs) {
			foreach (var server in client.GetServersList()) {
				Console.WriteLine("Connected to server " + server.name + " (" + server.id + ")");
				m_discordServers.Add(new DiscordServerData(server));
			}
		}

		private void parseMessage(object a_sender, DiscordMessageEventArgs a_eventArgs) {
			string[] message = a_eventArgs.message.content.Split(' ');
			DiscordChannel channel = a_eventArgs.Channel;

			if (message.Length == 0) {
				return;
			}
			if (!message[0].StartsWith("!")) {
				return;
			}

			string command = message[0].Substring(1);

			if (command == "time") {
				handleTimeCommand(message.Length == 1 ? null : message[1], channel);
			} else if (command == "harpunen") {
				client.SendMessageToChannel("https://www.youtube.com/watch?v=93Tj2bCslBk", channel);
			} else if (command == "penis") {
				client.SendMessageToChannel("https://www.youtube.com/watch?v=1qe2MDdfw1g", channel);
			} else if (command == "dboost") {
				client.SendMessageToChannel("http://i.imgur.com/cSAlF1d.jpg", channel);
			} else if (command == "quote") {
				if (a_eventArgs.message.content.Length >= 7) {
					handleQuote(a_eventArgs.message.content.Substring(7), a_eventArgs.author, channel);
				} else {
					handleQuote("", a_eventArgs.author, channel);
				}
			} else if (command == "d2r") {
				if (a_eventArgs.message.content.Length >= 5) {
					handleDiablo2(a_eventArgs.message.content.Substring(5), channel);
				} else {
					handleDiablo2("", channel);
				}
			} else if (command == "version") {
				client.SendMessageToChannel(VERSION, channel);
			} else if (command == "commands") {
				client.SendMessageToChannel(COMMANDS, channel);
			}
		}

		private void handleTimeCommand(string a_timeArg1, DiscordChannel a_channel) {
			client.SendMessageToChannel(TimeFunctions.getTimeForLocation(a_timeArg1), a_channel);
		}

		private void handleQuote(string a_quoteMessage, DiscordMember a_sender, DiscordChannel a_channel) {
			if (a_quoteMessage == null || a_quoteMessage.Trim() == "") {
				client.SendMessageToChannel(QUOTE_USAGE, a_channel);
				return;
			}

			DiscordServerData ds = m_discordServers.Find(x => x.Server == a_channel.parent);

			if (ds == null) {
				return;
			}

			string command = a_quoteMessage.Split(' ')[0].Trim();

			if (command == "get") {
				if (a_quoteMessage.Length > 3) {
					client.SendMessageToChannel(ds.getRandomQuote(a_quoteMessage.Substring(4).Split(' ')[0]), a_channel);
				} else {
					client.SendMessageToChannel(ds.getRandomQuote(""), a_channel);
				}

				return;
			} else if (command == "add") {
				if (a_quoteMessage.Length > 3) {
					client.SendMessageToChannel(ds.addQuote(a_quoteMessage.Substring(4)), a_channel);
				} else {
					client.SendMessageToChannel(ds.addQuote(""), a_channel);
				}

				return;
			} else if (command == "remove") {
				if (a_quoteMessage.Length > 6) {
					client.SendMessageToChannel(ds.removeQuotesForUser(a_quoteMessage.Substring(7).Split(' ')[0]), a_channel);
				} else {
					client.SendMessageToChannel(ds.removeQuotesForUser(""), a_channel);
				}

				return;
			} else if (command == "clear") {
				client.SendMessageToChannel(ds.clearQuotes(a_sender), a_channel);
				return;
			} else if (command == "count") {
				client.SendMessageToChannel(ds.getQuoteCount(), a_channel);
				return;
			}
			client.SendMessageToChannel(QUOTE_USAGE, a_channel);
		}

		private void handleDiablo2(string a_argString, DiscordChannel a_channel) {
			if (a_argString.Trim() == "") {
				client.SendMessageToChannel(D2_USAGE, a_channel);
				return;
			}

			string[] splitArgument = a_argString.Split(' ');
			string command = splitArgument[0];

			if (command == "find") {
				if (splitArgument.Length > 1) {
					try {
						client.SendMessageToChannel(DiscordBotDiablo2.Diablo2Plugin.getPossibleWords(splitArgument[1], int.Parse(splitArgument[2])), a_channel);
					} catch (FormatException) {
						try {
							client.SendMessageToChannel(DiscordBotDiablo2.Diablo2Plugin.getPossibleWords(splitArgument[2], int.Parse(splitArgument[1])), a_channel);
						} catch (FormatException) {
							string[] runes = new string[splitArgument.Length - 1];

							for (int i = 0; i < runes.Length; ++i) {
								runes[i] = splitArgument[i + 1];
							}

							client.SendMessageToChannel(DiscordBotDiablo2.Diablo2Plugin.getMatchingRunewords(runes), a_channel);
						}
					}
				} else {
					client.SendMessageToChannel(EMSG_D2_NO_ITEM, a_channel);
				}
				return;
			} else {
				client.SendMessageToChannel(DiscordBotDiablo2.Diablo2Plugin.getRuneword(a_argString), a_channel);
				return;
			}
		}
	}
}
