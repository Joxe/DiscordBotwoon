using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DiscordBot.Plugins;
using DiscordBot.Plugins.D2Plugin;
using DSharpPlus;
using DSharpPlus.Net.WebSocket;

namespace DiscordBot {
	class DiscordMain {
		public static List<DiscordPlugin> Plugins { get; private set; }
		
		private static DiscordClient m_discordClient;

		static void Main(string[] args) {
			MainAsync(args).ConfigureAwait(false).GetAwaiter().GetResult();
		}

		static async Task MainAsync(string[] a_args) {
			m_discordClient = new DiscordClient(
				new DiscordConfiguration {
					#if false
					Token = "MTg0MjgyODQ4NzcxOTY0OTI4.DNIJ2w.FuXpro3-55bZNMD9hU3utpFrRto",
					#else
					Token = "MzcyNzU5MjcxMDEzNjEzNTY4.DNI2pQ.yuP1ZS2tdcnMD0XdyG_MecVtRH0",
					#endif
					TokenType = TokenType.Bot 
				});

			m_discordClient.SetWebSocketClient<WebSocketSharpClient>();

			Console.WriteLine("Loading Plugins");

			Plugins = new List<DiscordPlugin> {
				new TimePlugin(m_discordClient),
				new Diablo2Plugin(m_discordClient),
				new HarpunenPlugin(m_discordClient),
				new PenisPlugin(m_discordClient),
				new DamageBoostPlugin(m_discordClient),
				new CommandsPlugin(m_discordClient),
				new VersionPlugin(m_discordClient),
				new QuotePlugin(m_discordClient)
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
