using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordBot {
	[Serializable]
	class RemindEvent {
		public string UserId { get; private set; }
		public DateTime TimeToRemind { get; private set; }
		public string RemindMessage { get; private set; }

		public RemindEvent(string a_userId, DateTime a_timeToRemind, string a_remindMessage) {
			UserId        = a_userId;
			TimeToRemind  = a_timeToRemind;
			RemindMessage = a_remindMessage;
		}
	}
}
