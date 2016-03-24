using System.Collections.Generic;
using System.Text;

namespace DiscordBotDiablo2 {
	class Diablo2Plugin {
		private const string NO_RUNEWORD = "Found no rune word with the name \"{0}\".";
		private const string NO_POSSIBLE_RUNEWORDS = "There are no possible runewords for a {0} Socket {1}.";
		private const string POSSIBLE_RUNEWORDS_FROM_ITEM = "The possible Rune Words for a {0} Socket {1} is as follows:";
		private const string POSSIBLE_RUNEWORDS_FROM_RUNES = "The possible Rune Words your runes ({0}) are as follows:";

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
