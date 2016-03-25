using System;
using System.Linq;

namespace DiscordBot {
	class TimeFunctions {
		private const string TIME_USAGE = "Time Command Usage\n!time\n!time aus|anton|jap|usw|valve";
		private const string TIME_MY_TIME = "My system time is: {0}";
		private const string TIME_AUS = "Time in Australia (East) is: {0}:{1}";
		private const string TIME_JAP = "Time in Japan is: {0}:{1}";
		private const string TIME_USW = "Time on the US West Coast is: {0}:{1}";

		//TODO concider daylight savings
		private const int AUS_TIME_DIFF = 10;
		private const int JAP_TIME_DIFF = 8;
		private const int USW_TIME_DIFF = -8;

		private readonly static string[] AUS_MATCHES = {
			"aus", "anton", "kangarooland", "poison", "down under"
		};

		private readonly static string[] JAP_MATCHES = {
			"jap", "nippon", "anime", "manga", "weeb"
		};

		private readonly static string[] USW_MATCHES = {
			"usw", "valve"
		};

		public static string getTimeForLocation(string a_location) {
			if (string.IsNullOrWhiteSpace(a_location)) {
				return string.Format(TIME_MY_TIME, DateTime.Now.ToString()) + "\n" + TIME_USAGE;
			}
			a_location = a_location.ToLower();
			if (AUS_MATCHES.Contains(a_location)) {
				return formatTimeDiff(TIME_AUS, AUS_TIME_DIFF);
			}
			if (JAP_MATCHES.Contains(a_location)) {
				return formatTimeDiff(TIME_JAP, JAP_TIME_DIFF);
			}
			if (USW_MATCHES.Contains(a_location)) {
				return formatTimeDiff(TIME_USW, USW_TIME_DIFF);
			}

			return TIME_USAGE;
		}

		public static string formatTimeDiff(string str, int timeDiff) {
			return formatTime(str, DateTime.Now.AddHours(timeDiff));
		}

		public static string formatTime(string str, DateTime time) {
			return string.Format(str, time.Hour.ToString().PadLeft(2, '0'), time.Minute.ToString().PadLeft(2, '0'));
		}
	}
}
