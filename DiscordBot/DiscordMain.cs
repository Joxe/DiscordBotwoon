using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using DiscordSharp;
using DiscordBot.Plugins;
using DiscordBot.Plugins.D2Plugin;
using System.Text;
using System.Threading.Tasks;

namespace DiscordBot {
	class DiscordMain {
		public List<DiscordPlugin> Plugins { get; private set; }

		private DiscordClient m_client = new DiscordClient();
		private Thread m_eventThread;
		private bool m_hasStartedConnecting = false;

		public DiscordMain() {
			if (!File.Exists("credentials.txt")) {
				throw new FileNotFoundException("No 'credentials.txt' found, make sure that it's placed in the same directory as the executable!");
			}

			m_client.Connected += onConnected;

			while (true) {
				if (m_eventThread == null || (!m_client.WebsocketAlive && !m_hasStartedConnecting)) {
					connect();
				}
				Thread.Sleep(100);
			}
		}

		private void connect() {
			m_hasStartedConnecting = true;
			using (StreamReader sr = new StreamReader("credentials.txt")) {
				m_client.ClientPrivateInformation.email = sr.ReadLine();
				m_client.ClientPrivateInformation.password = sr.ReadLine();
			}

			m_client.SendLoginRequest();

			Plugins = new List<DiscordPlugin>();

			Plugins.Add(new TimePlugin(this));
			Plugins.Add(new Diablo2Plugin(this));
			Plugins.Add(new HarpunenPlugin(this));
			Plugins.Add(new PenisPlugin(this));
			Plugins.Add(new DamageBoostPlugin(this));
			Plugins.Add(new CommandsPlugin(this));
			Plugins.Add(new VersionPlugin(this));
			Plugins.Add(new QuotePlugin(this));

			for (int i = 0; i < Plugins.Count; ) {
				if (string.IsNullOrEmpty(Plugins[i].Command)) {
					Console.WriteLine(string.Format("Plugin \"{0}\" has no command, deleting from active list.", Plugins[i].ToString()));
					Plugins.RemoveAt(i);
					continue;
				}

				m_client.AudioPacketReceived             += Plugins[i].onAudioPacketReceived;
				m_client.BanRemoved                      += Plugins[i].onBanRemoved;
				m_client.ChannelCreated                  += Plugins[i].onChannelCreated;
				m_client.ChannelDeleted                  += Plugins[i].onChannelDeleted;
				m_client.ChannelUpdated                  += Plugins[i].onChannelUpdated;
				m_client.Connected                       += Plugins[i].onConnected;
				m_client.GuildCreated                    += Plugins[i].onGuildCreated;
				m_client.GuildDeleted                    += Plugins[i].onGuildDeleted;
				m_client.GuildMemberBanned               += Plugins[i].onGuildMemberBanned;
				m_client.GuildMemberUpdated              += Plugins[i].onGuildMemberUpdated;
				m_client.GuildUpdated                    += Plugins[i].onGuildUpdated;
				m_client.KeepAliveSent                   += Plugins[i].onKeepAliveSent;
				m_client.MentionReceived                 += Plugins[i].onMentionReceived;
				m_client.MessageDeleted                  += Plugins[i].onMessageDeleted;
				m_client.MessageEdited                   += Plugins[i].onMessageEdited;
				m_client.MessageReceived                 += Plugins[i].onMessageReceived;
				m_client.PresenceUpdated                 += Plugins[i].onPresenceUpdated;
				m_client.PrivateChannelCreated           += Plugins[i].onPrivateChannelCreated;
				m_client.PrivateChannelDeleted           += Plugins[i].onPrivateChannelDeleted;
				m_client.PrivateMessageDeleted           += Plugins[i].onPrivateMessageDeleted;
				m_client.PrivateMessageReceived          += Plugins[i].onPrivateMessageReceived;
				m_client.RoleDeleted                     += Plugins[i].onRoleDeleted;
				m_client.RoleUpdated                     += Plugins[i].onRoleUpdated;
				m_client.SocketClosed                    += Plugins[i].onSocketClosed;
				m_client.SocketOpened                    += Plugins[i].onSocketOpened;
				m_client.TextClientDebugMessageReceived  += Plugins[i].onTextClientDebugMessageReceived;
				m_client.UnknownMessageTypeReceived      += Plugins[i].onUnknownMessageTypeReceived;
				m_client.URLMessageAutoUpdate            += Plugins[i].onURLMessageAutoUpdate;
				m_client.UserAddedToServer               += Plugins[i].onUserAddedToServer;
				m_client.UserLeftVoiceChannel            += Plugins[i].onUserLeftVoiceChannel;
				m_client.UserRemovedFromServer           += Plugins[i].onUserRemovedFromServer;
				m_client.UserSpeaking                    += Plugins[i].onUserSpeaking;
				m_client.UserTypingStart                 += Plugins[i].onUserTypingStart;
				m_client.UserUpdate                      += Plugins[i].onUserUpdate;
				m_client.VoiceClientConnected            += Plugins[i].onVoiceClientConnected;
				m_client.VoiceClientDebugMessageReceived += Plugins[i].onVoiceClientDebugMessageReceived;
				m_client.VoiceQueueEmpty                 += Plugins[i].onVoiceQueueEmpty;
				m_client.VoiceStateUpdate                += Plugins[i].onVoiceStateUpdate;
				++i;
			}

			m_eventThread = new Thread(m_client.Connect);
			m_eventThread.Start();
		}

		public void onConnected(object a_sender, DiscordConnectEventArgs a_eventArgs) {
			Console.WriteLine($"Connected! User: { a_eventArgs.user.Username }");
			m_hasStartedConnecting = false;
		}

		public DiscordPlugin getPluginFromCommand(string a_command) {
			foreach (var plugin in Plugins) {
				if (plugin.Command == a_command) {
					return plugin;
				}
			}

			return null;
		}
	}
}
