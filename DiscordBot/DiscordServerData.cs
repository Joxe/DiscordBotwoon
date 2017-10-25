/*
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using DiscordSharp.Objects;

namespace DiscordBot {
	class DiscordServerData {
		public DiscordServer Server { get; private set; }

		private List<DiscordChannel> m_channels = new List<DiscordChannel>();
		private List<Quote> m_quotes = new List<Quote>();
		private List<RemindEvent> m_remindEvents = new List<RemindEvent>();

		private const string NO_QUOTES_ON_SERVER = "*No quotes saved for server*\n-Botwoon, {0}";
		private const string NO_QUOTES_BY_AUTHOR = "*No quotes saved for that author*\n-Botwoon, {0}";
		private const string REMOVED_QUOTES = "Removed {0} quotes";
		private const string CLEARED_QUOTES = "{0} cleared the server from {1} quotes.";
		private const string FAIELD_CLEARED_QUOTES = "{0} tried to clear the server from quotes but did not have permission, laugh at him/her!.";
		private const string ADD_QUOTE_SUCCESS = "Added quote from \"{0}\"!";
		private const string QUOTE_FILENAME = "-quotes.bin";
		private const string QUOTE_COUNT = "This server currently have {0} quotes saved";
		private const string EMSG_ADD_QUOTE_NO_MSG = "Can't add an empty quote, that would be madness!\nSpecify an author and quote by typing\n!quote add <author>;<quote>";
		private const string EMSG_ADD_QUOTE_ALREADY_EXISTS = "{0} is repeating itself, I already have one of those quotes!";
		private const string EMSG_REMOVE_FAILED_NO_AUTHOR = "Could not remove quotes from user as none was defined!";
		private const string EMSG_ADD_FAILED_NO_AUTHOR = "Could not add a quote from user as none was defined!";
		private const string EMSG_QUOTE_NO_MESSAGE = "{0} needs to say something for me to save it, silent quotes are strictly forbidden as per EU law.";

		public DiscordServerData(DiscordServer a_server) {
			foreach (var channel in a_server.Channels) {
				m_channels.Add(channel);
			}
			Server = a_server;

			loadQuotesForServer();
		}

		public string addQuote(string a_message) {
			if (string.IsNullOrEmpty(a_message)) {
				return EMSG_ADD_QUOTE_NO_MSG;
			}
			
			string[] splitString = a_message.Split(';');
			string author  = splitString.Length > 0 ? splitString[0] : null;
			string message = splitString.Length > 1 ? splitString[1] : null;

			if (string.IsNullOrEmpty(author)) {
				return EMSG_ADD_FAILED_NO_AUTHOR;
			}

			if (string.IsNullOrEmpty(message)) {
				return string.Format(EMSG_QUOTE_NO_MESSAGE, author);
			}

			Quote q = new Quote(author, message, DateTime.Now);

			foreach (var quote in m_quotes) {
				if (quote.isEqualQuote(q)) {
					return string.Format(EMSG_ADD_QUOTE_ALREADY_EXISTS, author);
				}
			}

			m_quotes.Add(q);
			saveQuotesForServer();
			return string.Format(ADD_QUOTE_SUCCESS, author);
		}

		public string getRandomQuote(string a_author = null) {
			Random r = new Random();
			if (string.IsNullOrEmpty(a_author)) {
				if (m_quotes.Count == 0) {
					return string.Format(NO_QUOTES_ON_SERVER, DateTime.Now.Year);
				} else {
					return m_quotes[r.Next(0, m_quotes.Count)].ToString();
				}
			}

			List<Quote> authorQuotes = new List<Quote>();
			foreach (var quote in m_quotes) {
				if (quote.Author.ToLower() == a_author.ToLower()) {
					authorQuotes.Add(quote);
				}
			}

			if (authorQuotes.Count == 0) {
				return string.Format(NO_QUOTES_BY_AUTHOR, DateTime.Now.Year);
			}
			
			return authorQuotes[r.Next(0, authorQuotes.Count - 1)].ToString();
		}

		public string removeQuotesForUser(string a_author) {
			if (a_author == null || a_author == "") {
				return EMSG_REMOVE_FAILED_NO_AUTHOR;
			}
			int quotesRemoved = 0;

			for (int i = 0; i < m_quotes.Count; ) {
				if (m_quotes[i].Author.ToLower() == a_author.ToLower()) {
					m_quotes.RemoveAt(i);
					++quotesRemoved;
					continue;
				}
				++i;
			}

			return string.Format(REMOVED_QUOTES, quotesRemoved);
		}

		public string clearQuotes(DiscordMember a_member) {
			bool allowedToClear = false;

			foreach (var role in a_member.Roles) {
				if (role.Permissions.HasPermission(DiscordSpecialPermissions.ManageServer)) {
					allowedToClear = true;
					break;
				}
			}

			if (allowedToClear) {
				int quotesRemoved = m_quotes.Count;
				m_quotes.Clear();
				saveQuotesForServer();
				return string.Format(CLEARED_QUOTES, a_member.Username, quotesRemoved);
			} else {
				return string.Format(FAIELD_CLEARED_QUOTES, a_member.Username);
			}
		}

		public string getQuoteCount() {
			return string.Format(QUOTE_COUNT, m_quotes.Count);
		}

		private void saveQuotesForServer() {
			IFormatter formatter = new BinaryFormatter();

			using (Stream stream = new FileStream(Server.ID + QUOTE_FILENAME, FileMode.Create, FileAccess.Write, FileShare.None)) {
				formatter.Serialize(stream, m_quotes);
				stream.Close();
			}
		}

		private void loadQuotesForServer() {
			IFormatter formatter = new BinaryFormatter();

			if (!File.Exists(Server.ID + QUOTE_FILENAME)) {
				return;
			}

			using (Stream stream = new FileStream(Server.ID + QUOTE_FILENAME, FileMode.Open, FileAccess.Read, FileShare.None)) {
				m_quotes = (List<Quote>)formatter.Deserialize(stream);
				stream.Close();
			}
		}
	}
}
*/
