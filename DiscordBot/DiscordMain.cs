/*
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Threading;
using DSharpPlus;
using DiscordBot.Plugins;
using DiscordBot.Plugins.D2Plugin;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace DiscordBot {
	class DiscordMain {
		public List<DiscordPlugin> Plugins { get; private set; }

		private DiscordClient m_discordClient;

		//private DiscordClient m_client = new DiscordClient();
		private Thread m_eventThread;
		private bool m_hasStartedConnecting = false;

		//Is this ok? I really need it in my plugin, man
		public DiscordClient Client {
			get {
				return m_client;
			}
		}

		public DiscordMain() {
			m_discordClient = new DiscordClient(
				new DiscordConfiguration {
					Token = "MTg0MjgyODQ4NzcxOTY0OTI4.DNIJ2w.FuXpro3-55bZNMD9hU3utpFrRto",
					TokenType = TokenType.Bot 
				});

			m_client.Connected += onConnected;

			m_client.AudioPacketReceived += onAudioPacketReceived;
			m_client.BanRemoved += onBanRemoved;
			m_client.ChannelCreated += onChannelCreated;
			m_client.ChannelDeleted += onChannelDeleted;
			m_client.ChannelUpdated += onChannelUpdated;
			m_client.GuildAvailable += onGuildAvailable;
			m_client.GuildCreated += onGuildCreated;
			m_client.GuildDeleted += onGuildDeleted;
			m_client.GuildMemberBanned += onGuildMemberBanned;
			m_client.GuildMemberUpdated += onGuildMemberUpdated;
			m_client.GuildUpdated += onGuildUpdated;
			m_client.KeepAliveSent += onKeepAliveSent;
			m_client.MentionReceived += onMentionReceived;
			m_client.MessageDeleted += onMessageDeleted;
			m_client.MessageEdited += onMessageEdited;
			m_client.MessageReceived += onMessageReceived;
			m_client.PresenceUpdated += onPresenceUpdated;
			m_client.PrivateChannelCreated += onPrivateChannelCreated;
			m_client.PrivateChannelDeleted += onPrivateChannelDeleted;
			m_client.PrivateMessageDeleted += onPrivateMessageDeleted;
			m_client.PrivateMessageReceived += onPrivateMessageReceived;
			m_client.RoleDeleted += onRoleDeleted;
			m_client.RoleUpdated += onRoleUpdated;
			m_client.SocketClosed += onSocketClosed;
			m_client.SocketOpened += onSocketOpened;
			m_client.TextClientDebugMessageReceived += onTextClientDebugMessageReceived;
			m_client.UnknownMessageTypeReceived += onUnknownMessageTypeReceived;
			m_client.URLMessageAutoUpdate += onURLMessageAutoUpdate;
			m_client.UserAddedToServer += onUserAddedToServer;
			m_client.UserLeftVoiceChannel += onUserLeftVoiceChannel;
			m_client.UserRemovedFromServer += onUserRemovedFromServer;
			m_client.UserSpeaking += onUserSpeaking;
			m_client.UserTypingStart += onUserTypingStart;
			m_client.UserUpdate += onUserUpdate;
			m_client.VoiceClientConnected += onVoiceClientConnected;
			m_client.VoiceClientDebugMessageReceived += onVoiceClientDebugMessageReceived;
			m_client.VoiceQueueEmpty += onVoiceQueueEmpty;
			m_client.VoiceStateUpdate += onVoiceStateUpdate;

			while (true) {
				if (m_eventThread == null || (!m_client.WebsocketAlive && !m_hasStartedConnecting)) {
					connect();
				}
				Thread.Sleep(100);
			}
		}

		private void connect() {
			m_hasStartedConnecting = true;

			m_client.ClientPrivateInformation.Email = "jclysen@gmail.com";
			m_client.ClientPrivateInformation.Password = "bris";

			Console.WriteLine("Sending login request.");
			try {
				Console.WriteLine(m_client.SendLoginRequest());
				m_eventThread = new Thread(m_client.Connect);
				m_eventThread.Start();
			} catch (Exception e) {
				Console.WriteLine(e);
			}
		}

		public void onConnected(object a_sender, DiscordConnectEventArgs a_eventArgs) {
			Console.WriteLine($"Connected! User: { a_eventArgs.User.Username }");
			m_hasStartedConnecting = false;

			Plugins = new List<DiscordPlugin> {
				new TimePlugin(this),
				new Diablo2Plugin(this),
				new HarpunenPlugin(this),
				new PenisPlugin(this),
				new DamageBoostPlugin(this),
				new CommandsPlugin(this),
				new VersionPlugin(this),
				new QuotePlugin(this),
				new MessageFindPlugin(this)
			};

			for (int i = 0; i < Plugins.Count;) {
				if (string.IsNullOrEmpty(Plugins[i].Command)) {
					Console.WriteLine(string.Format("Plugin \"{0}\" has no command, deleting from active list.", Plugins[i].ToString()));
					Plugins.RemoveAt(i);
					continue;
				} else {
					Console.WriteLine("Adding plugin: " + Plugins[i].ToString());
				}

				m_client.AudioPacketReceived += Plugins[i].onAudioPacketReceived;
				m_client.BanRemoved += Plugins[i].onBanRemoved;
				m_client.ChannelCreated += Plugins[i].onChannelCreated;
				m_client.ChannelDeleted += Plugins[i].onChannelDeleted;
				m_client.ChannelUpdated += Plugins[i].onChannelUpdated;
				m_client.Connected += Plugins[i].onConnected;
				m_client.GuildCreated += Plugins[i].onGuildCreated;
				m_client.GuildDeleted += Plugins[i].onGuildDeleted;
				m_client.GuildMemberBanned += Plugins[i].onGuildMemberBanned;
				m_client.GuildMemberUpdated += Plugins[i].onGuildMemberUpdated;
				m_client.GuildUpdated += Plugins[i].onGuildUpdated;
				m_client.KeepAliveSent += Plugins[i].onKeepAliveSent;
				m_client.MentionReceived += Plugins[i].onMentionReceived;
				m_client.MessageDeleted += Plugins[i].onMessageDeleted;
				m_client.MessageEdited += Plugins[i].onMessageEdited;
				m_client.MessageReceived += Plugins[i].onMessageReceived;
				m_client.PresenceUpdated += Plugins[i].onPresenceUpdated;
				m_client.PrivateChannelCreated += Plugins[i].onPrivateChannelCreated;
				m_client.PrivateChannelDeleted += Plugins[i].onPrivateChannelDeleted;
				m_client.PrivateMessageDeleted += Plugins[i].onPrivateMessageDeleted;
				m_client.PrivateMessageReceived += Plugins[i].onPrivateMessageReceived;
				m_client.RoleDeleted += Plugins[i].onRoleDeleted;
				m_client.RoleUpdated += Plugins[i].onRoleUpdated;
				m_client.SocketClosed += Plugins[i].onSocketClosed;
				m_client.SocketOpened += Plugins[i].onSocketOpened;
				m_client.TextClientDebugMessageReceived += Plugins[i].onTextClientDebugMessageReceived;
				m_client.UnknownMessageTypeReceived += Plugins[i].onUnknownMessageTypeReceived;
				m_client.URLMessageAutoUpdate += Plugins[i].onURLMessageAutoUpdate;
				m_client.UserAddedToServer += Plugins[i].onUserAddedToServer;
				m_client.UserLeftVoiceChannel += Plugins[i].onUserLeftVoiceChannel;
				m_client.UserRemovedFromServer += Plugins[i].onUserRemovedFromServer;
				m_client.UserSpeaking += Plugins[i].onUserSpeaking;
				m_client.UserTypingStart += Plugins[i].onUserTypingStart;
				m_client.UserUpdate += Plugins[i].onUserUpdate;
				m_client.VoiceClientConnected += Plugins[i].onVoiceClientConnected;
				m_client.VoiceClientDebugMessageReceived += Plugins[i].onVoiceClientDebugMessageReceived;
				m_client.VoiceQueueEmpty += Plugins[i].onVoiceQueueEmpty;
				m_client.VoiceStateUpdate += Plugins[i].onVoiceStateUpdate;
				++i;
			}
		}

		public DiscordPlugin getPluginFromCommand(string a_command) {
			return Plugins.SingleOrDefault(x => string.Compare(x.Command, a_command, true) == 0);
		}

		public void OnAudioPacketReceived(object a_sender, DiscordAudioPacketEventArgs a_args) {
			Console.WriteLine(new StackTrace().GetFrame(0).GetMethod());
		}

		public void OnBanRemoved(object a_sender, DiscordBanRemovedEventArgs a_args) {
			Console.WriteLine(new StackTrace().GetFrame(0).GetMethod());
		}

		public void OnChannelCreated(object a_sender, DiscordChannelCreateEventArgs a_args) {
			Console.WriteLine(new StackTrace().GetFrame(0).GetMethod());
		}

		public void OnChannelDeleted(object a_sender, DiscordChannelDeleteEventArgs a_args) {
			Console.WriteLine(new StackTrace().GetFrame(0).GetMethod());
		}

		public void OnChannelUpdated(object a_sender, DiscordChannelUpdateEventArgs a_args) {
			Console.WriteLine(new StackTrace().GetFrame(0).GetMethod());
		}

		public void OnGuildAvailable(object a_sender, DiscordGuildCreateEventArgs a_args) {
			Console.WriteLine(new StackTrace().GetFrame(0).GetMethod());
		}

		public void OnGuildCreated(object a_sender, DiscordGuildCreateEventArgs a_args) {
			Console.WriteLine(new StackTrace().GetFrame(0).GetMethod());
		}

		public void OnGuildDeleted(object a_sender, DiscordGuildDeleteEventArgs a_args) {
			Console.WriteLine(new StackTrace().GetFrame(0).GetMethod());
		}

		public void OnGuildMemberBanned(object a_sender, DiscordGuildBanEventArgs a_args) {
			Console.WriteLine(new StackTrace().GetFrame(0).GetMethod());
		}

		public void OnGuildMemberUpdated(object a_sender, DiscordGuildMemberUpdateEventArgs a_args) {
			Console.WriteLine(new StackTrace().GetFrame(0).GetMethod());
		}

		public void OnGuildUpdated(object a_sender, DiscordServerUpdateEventArgs a_args) {
			Console.WriteLine(new StackTrace().GetFrame(0).GetMethod());
		}

		public void OnKeepAliveSent(object a_sender, DiscordKeepAliveSentEventArgs a_args) {
			Console.WriteLine(new StackTrace().GetFrame(0).GetMethod());
		}

		public void OnMentionReceived(object a_sender, DiscordMessageEventArgs a_args) {
			Console.WriteLine(new StackTrace().GetFrame(0).GetMethod());
		}

		public void OnMessageDeleted(object a_sender, DiscordMessageDeletedEventArgs a_args) {
			Console.WriteLine(new StackTrace().GetFrame(0).GetMethod());
		}

		public void OnMessageEdited(object a_sender, DiscordMessageEditedEventArgs a_args) {
			Console.WriteLine(new StackTrace().GetFrame(0).GetMethod());
		}

		public void OnMessageReceived(object a_sender, DiscordMessageEventArgs a_args) {
			Console.WriteLine(new StackTrace().GetFrame(0).GetMethod());
		}

		public void OnPresenceUpdated(object a_sender, DiscordPresenceUpdateEventArgs a_args) {
			Console.WriteLine(new StackTrace().GetFrame(0).GetMethod());
		}

		public void OnPrivateChannelCreated(object a_sender, DiscordPrivateChannelEventArgs a_args) {
			Console.WriteLine(new StackTrace().GetFrame(0).GetMethod());
		}

		public void OnPrivateChannelDeleted(object a_sender, DiscordPrivateChannelDeleteEventArgs a_args) {
			Console.WriteLine(new StackTrace().GetFrame(0).GetMethod());
		}

		public void OnPrivateMessageDeleted(object a_sender, DiscordPrivateMessageDeletedEventArgs a_args) {
			Console.WriteLine(new StackTrace().GetFrame(0).GetMethod());
		}

		public void OnPrivateMessageReceived(object a_sender, DiscordPrivateMessageEventArgs a_args) {
			Console.WriteLine(new StackTrace().GetFrame(0).GetMethod());
		}

		public void OnRoleDeleted(object a_sender, DiscordGuildRoleDeleteEventArgs a_args) {
			Console.WriteLine(new StackTrace().GetFrame(0).GetMethod());
		}

		public void OnRoleUpdated(object a_sender, DiscordGuildRoleUpdateEventArgs a_args) {
			Console.WriteLine(new StackTrace().GetFrame(0).GetMethod());
		}

		public void OnSocketClosed(object a_sender, DiscordSocketClosedEventArgs a_args) {
			Console.WriteLine("onSocketClosed: " + a_args.Reason);
		}

		public void OnSocketOpened(object a_sender, EventArgs a_args) {
			Console.WriteLine(new StackTrace().GetFrame(0).GetMethod());
		}

		public void OnTextClientDebugMessageReceived(object a_sender, LoggerMessageReceivedArgs a_args) {
			Console.WriteLine("Debug: " + a_args.message.Message);
		}

		public void OnUnknownMessageTypeReceived(object a_sender, UnknownMessageEventArgs a_args) {
			Console.WriteLine(new StackTrace().GetFrame(0).GetMethod());
		}

		public void OnURLMessageAutoUpdate(object a_sender, DiscordURLUpdateEventArgs a_args) {
			Console.WriteLine(new StackTrace().GetFrame(0).GetMethod());
		}

		public void OnUserAddedToServer(object a_sender, DiscordGuildMemberAddEventArgs a_args) {
			Console.WriteLine(new StackTrace().GetFrame(0).GetMethod());
		}

		public void OnUserLeftVoiceChannel(object a_sender, DiscordLeftVoiceChannelEventArgs a_args) {
			Console.WriteLine(new StackTrace().GetFrame(0).GetMethod());
		}

		public void OnUserRemovedFromServer(object a_sender, DiscordGuildMemberRemovedEventArgs a_args) {
			Console.WriteLine(new StackTrace().GetFrame(0).GetMethod());
		}

		public void OnUserSpeaking(object a_sender, DiscordVoiceUserSpeakingEventArgs a_args) {
			Console.WriteLine(new StackTrace().GetFrame(0).GetMethod());
		}

		public void OnUserTypingStart(object a_sender, DiscordTypingStartEventArgs a_args) {
			Console.WriteLine(new StackTrace().GetFrame(0).GetMethod());
		}

		public void OnUserUpdate(object a_sender, DiscordUserUpdateEventArgs a_args) {
			Console.WriteLine(new StackTrace().GetFrame(0).GetMethod());
		}

		public void OnVoiceClientConnected(object a_sender, EventArgs a_args) {
			Console.WriteLine(new StackTrace().GetFrame(0).GetMethod());
		}

		public void OnVoiceClientDebugMessageReceived(object a_sender, LoggerMessageReceivedArgs a_args) {
			Console.WriteLine(new StackTrace().GetFrame(0).GetMethod());
		}

		public void OnVoiceQueueEmpty(object a_sender, EventArgs a_args) {
			Console.WriteLine(new StackTrace().GetFrame(0).GetMethod());
		}

		public void OnVoiceStateUpdate(object a_sender, DiscordVoiceStateUpdateEventArgs a_args) {
			Console.WriteLine(new StackTrace().GetFrame(0).GetMethod());
		}
	}
}
*/
