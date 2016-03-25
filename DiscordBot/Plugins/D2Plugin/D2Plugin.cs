using System;
using System.Text;
using System.Collections.Generic;
using DiscordBot;
using DiscordSharp.Events;

namespace DiscordBot.Plugins.D2Plugin {
	class Diablo2Plugin : DiscordPlugin {
		private const string NO_RUNEWORD = "Found no rune word with the name \"{0}\".";
		private const string NO_POSSIBLE_RUNEWORDS = "There are no possible runewords for a {0} Socket {1}.";
		private const string POSSIBLE_RUNEWORDS_FROM_ITEM = "The possible Rune Words for a {0} Socket {1} is as follows:";
		private const string POSSIBLE_RUNEWORDS_FROM_RUNES = "The possible Rune Words your runes ({0}) are as follows:";
		private const string D2_USAGE = "Diablo 2 Command Usage\n!d2r <runeword name>\n!d2r find <itemtype> <sockets>\n!d2r find <runes>";
		private const string EMSG_D2_CANT_FIND_SOCKETS = "I can't understand how many sockets the item you specified has!";
		private const string EMSG_D2_NO_ITEM = "You have no specified an item to look for!";

		public Diablo2Plugin(DiscordMain a_discordMain) : base(a_discordMain) {
			Command = "!d2r";
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
				a_eventArgs.Channel.SendMessage(D2_USAGE);
				return;
			}

			if (splitString[1] == "find") {
				if (splitString.Length > 2) {
					try {
						a_eventArgs.Channel.SendMessage(getPossibleWords(splitString[2], int.Parse(splitString[3])));
					} catch (FormatException) {
						try {
							a_eventArgs.Channel.SendMessage(getPossibleWords(splitString[3], int.Parse(splitString[2])));
						} catch (FormatException) {
							string[] runes = new string[splitString.Length - 2];

							for (int i = 0; i < runes.Length; ++i) {
								runes[i] = splitString[i + 2];
							}

							a_eventArgs.Channel.SendMessage(getMatchingRunewords(runes));
						}
					}
				} else {
					a_eventArgs.Channel.SendMessage(EMSG_D2_NO_ITEM);
				}
				return;
			} else {
				a_eventArgs.Channel.SendMessage(getRuneword(splitString[1]));
				return;
			}
		}

		public override string ToString() {
			return "Diablo 2 Plugin";
		}

		public static string getRuneword(string a_runeword) {
			foreach (var runeword in Runeword.RUNEWORDS) {
				if (runeword.Name.ToLower() == a_runeword.ToLower()) {
					return runeword.ToString();
				}
			}
			return string.Format(NO_RUNEWORD, a_runeword);
		}

		public static string getPossibleWords(string a_itemType, int a_sockets) {
			List<Runeword> possibleWords = new List<Runeword>();

			foreach (var runeword in Runeword.RUNEWORDS) {
				bool checkSockets = false;

				foreach (var itemType in runeword.ItemType) {
					if (itemType.ToLower().Contains(a_itemType.ToLower())) {
						checkSockets = true;
					}
				}

				if (checkSockets && runeword.Sockets == a_sockets) {
					possibleWords.Add(runeword);
				}
			}

			if (possibleWords.Count == 0) {
				return string.Format(NO_POSSIBLE_RUNEWORDS, a_sockets, a_itemType);
			}

			StringBuilder returnString = new StringBuilder();

			returnString.AppendLine(string.Format(POSSIBLE_RUNEWORDS_FROM_ITEM, a_sockets, a_itemType));

			foreach (var runeword in possibleWords) {
				returnString.Append(runeword.Name);
				returnString.Append(" - ");
				returnString.AppendLine(runeword.getRunesAsString());
			}

			return returnString.ToString();
		}

		public static string getMatchingRunewords(string[] a_runes) {
			List<Runeword> validRunewords = new List<Runeword>();

			foreach (var runeword in Runeword.RUNEWORDS) {
				bool validRuneword = false;

				if (runeword.Runes.Length > a_runes.Length) {
					continue;
				}

				foreach (var rune in runeword.Runes) {
					foreach (var argumentRune in a_runes) {
						validRuneword = rune.ToLower() == argumentRune.ToLower();

						if (validRuneword) {
							break;
						}
					}
					if (!validRuneword) {
						break;
					}
				}

				if (validRuneword) {
					validRunewords.Add(runeword);
				}
			}

			StringBuilder runeString = new StringBuilder();
			for (int i = 0; i < a_runes.Length; ++i) {
				runeString.Append(a_runes[i]);

				if (i + 1 != a_runes.Length) {
					runeString.Append(" + ");
				}
			}
			StringBuilder returnString = new StringBuilder();

			returnString.AppendLine(string.Format(POSSIBLE_RUNEWORDS_FROM_RUNES, runeString.ToString()));

			foreach (var runeword in validRunewords) {
				returnString.AppendLine(runeword.ToSingleLineString());
			}

			return returnString.ToString();
		}
	}
}
