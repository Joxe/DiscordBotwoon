using System;
using System.Linq;

namespace DiscordBot {
	class TimeFunctions {
		private const string TIME_USAGE = "Time Command Usage\n!time\n!time aus|anton|jap|usw|valve";
		private const string TIME_MY_TIME = "My system time is: {0}";
		private const string TIME_AUS = "Time in Australia (East) is: {0}:{1}";
		private const string TIME_JAP = "Time in Japan is: {0}:{1}";
		private const string TIME_USW = "Time on the US West Coast is: {0}:{1}";

		private readonly static string[] AUS_MATCHES = {
			"aus", "anton", "kangarooland", "poison"
		};

		private readonly static string[] JAP_MATCHES = {
			"jap", "nippon", "anime", "manga", "weeb"
		};

		private readonly static string[] USW_MATCHES = {
			"usw", "valve"
		};

		public static string getTimeForLocation(string a_location) {
			if (a_location == null || a_location.Length == 0) {
				return string.Format(TIME_MY_TIME, DateTime.Now.ToString()) + "\n" + TIME_USAGE;
			}
			if (AUS_MATCHES.First(x => x == a_location.ToLower()) != null) {
				DateTime dt = DateTime.Now.AddHours(10.0);
				return string.Format(TIME_AUS, dt.Hour.ToString().PadLeft(2, '0'), dt.Minute.ToString().PadLeft(2, '0'));
			}
			if (JAP_MATCHES.First(x => x == a_location.ToLower()) != null) {
				DateTime dt = DateTime.Now.AddHours(8.0);
				return string.Format(TIME_JAP, dt.Hour.ToString().PadLeft(2, '0'), dt.Minute.ToString().PadLeft(2, '0'));
			}
			if (USW_MATCHES.First(x => x == a_location.ToLower()) != null) {
				DateTime dt = DateTime.Now.AddHours(-8.0);
				return string.Format(TIME_USW, dt.Hour.ToString().PadLeft(2, '0'), dt.Minute.ToString().PadLeft(2, '0'));
			}

			return TIME_USAGE;
		}
	}
}
