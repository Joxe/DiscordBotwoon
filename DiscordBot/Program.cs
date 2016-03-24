using System;
using System.IO;

namespace DiscordBot {
	class Program {
		static void Main(string[] args) {
			try {
				DiscordMain dm = new DiscordMain();
			} catch (FileNotFoundException fnfe) {
				Console.WriteLine(fnfe.Message);

				Console.WriteLine("Press any key to exit.");
				Console.ReadKey();
			}
		}
	}
}
