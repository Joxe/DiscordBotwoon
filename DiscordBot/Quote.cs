using System;

namespace DiscordBot {
	[Serializable]
	public class Quote {
		public string Author  { get; private set; }
		public string Message { get; private set; }
		public DateTime Time  { get; private set; }

		public Quote(string a_author, string a_message, DateTime a_time) {
			Author = a_author;
			Message = a_message;
			Time = a_time;
		}

		public bool isEqualQuote(Quote a_other) {
			return Author.ToLower() == a_other.Author.ToLower() && Message.ToLower() == a_other.Message.ToLower();
		}

		public override string ToString() {
			return String.Format("*\"{0}\"*\n-{1}, {2} - {3}/{4}", Message, Author, Time.Year, Time.Month, Time.Day);
		}
	}
}
