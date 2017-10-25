using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DiscordBot.Plugins;
using DiscordBot.Plugins.D2Plugin;
using DSharpPlus;

namespace DiscordBot {
	class DiscordMain {
		public static List<DiscordPlugin> Plugins { get; private set; }
		
		private static DiscordClient m_discordClient;

		static void Main(string[] args) {
			MainAsync(args).ConfigureAwait(false).GetAwaiter().GetResult();
			/*
			try {
				DiscordMain dm = new DiscordMain();
			} catch (FileNotFoundException fnfe) {
				Console.WriteLine(fnfe.Message);

				Console.WriteLine("Press any key to exit.");
				Console.ReadKey();
			}
			*/
		}

		static async Task MainAsync(string[] a_args) {
			m_discordClient = new DiscordClient(
				new DiscordConfiguration {
					Token = "MTg0MjgyODQ4NzcxOTY0OTI4.DNIJ2w.FuXpro3-55bZNMD9hU3utpFrRto",
					TokenType = TokenType.Bot 
				});

			Console.WriteLine("Loading Plugins");

			Plugins = new List<DiscordPlugin> {
				new TimePlugin(m_discordClient),
				new Diablo2Plugin(m_discordClient),
				new HarpunenPlugin(m_discordClient)/*,
				new PenisPlugin(this),
				new DamageBoostPlugin(this),
				new CommandsPlugin(this),
				new VersionPlugin(this),
				new QuotePlugin(this)*/
			};

			Console.WriteLine("Connecting...");

			await m_discordClient.ConnectAsync();

			Console.WriteLine("CurrentApplication: " + m_discordClient.CurrentApplication);
			Console.WriteLine("CurrentUser: " + m_discordClient.CurrentUser);
			Console.WriteLine("Gateway URL: " + m_discordClient.GatewayUrl);
			Console.WriteLine("Connected? DSharpPlus version " + m_discordClient.VersionString);
			
			await Task.Delay(-1);
		}
	}
}
