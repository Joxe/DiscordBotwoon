/*
using DiscordSharp;
using DiscordSharp.Objects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DiscordBot {
	public class MessageHistoryIterator : IEnumerable<List<DiscordMessage>> {

		private readonly int pageSize;
		private readonly int maxPages;
		private DiscordClient client;
		private DiscordChannel channel;

		public MessageHistoryIterator(int a_pageSize, int a_maxPages, DiscordClient a_client, DiscordChannel a_channel) {
			if (a_pageSize <= 0)
				throw new ArgumentOutOfRangeException("a_pageSize");
			if (a_client == null)
				throw new ArgumentNullException("a_client");
			if(a_channel == null)
				throw new ArgumentNullException("a_channel");	
			pageSize = a_pageSize;
			maxPages = a_maxPages;
			client = a_client;
			channel = a_channel;
		}

		private class MessageHistoryIteration : IEnumerator<List<DiscordMessage>> {

			private MessageHistoryIterator iterator;
			private List<DiscordMessage> currentPage;
			private int pageIndex = 0;

			public MessageHistoryIteration(MessageHistoryIterator a_iterator) {
				iterator = a_iterator;
			}

			public bool MoveNext() {
				if((iterator.maxPages >= 0 && pageIndex >= iterator.maxPages) || (currentPage != null && currentPage.Count == 0)) {
					return false;
				}
				string beforeId = currentPage == null ? null : currentPage[0].id;
				currentPage = iterator.client.GetMessageHistory(iterator.channel, iterator.pageSize, beforeId);
				++pageIndex;
				return currentPage == null || currentPage.Count == 0;
			}

			public void Reset() {
				currentPage = null;
				pageIndex = 0;
			}

			public List<DiscordMessage> Current {
				get {
					return currentPage;
				}
			}

			object System.Collections.IEnumerator.Current {
				get {
					return currentPage;
				}
			}

			void IDisposable.Dispose() {
			}
		}

		public IEnumerator<List<DiscordMessage>> GetEnumerator() {
			return new MessageHistoryIteration(this);
		}

		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() {
			return new MessageHistoryIteration(this);
		}

		public IEnumerable<DiscordMessage> flatten(){
			return this.SelectMany(x => x);
		}

		public static IEnumerable<DiscordMessage> flatten(int a_pageSize, int a_maxPages,
			DiscordClient a_client, DiscordChannel a_channel){
			return (new MessageHistoryIterator(a_pageSize, a_maxPages, a_client, a_channel)).flatten();
		}
	}
}
*/
