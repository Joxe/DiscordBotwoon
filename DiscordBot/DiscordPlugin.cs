using System;
using System.Threading.Tasks;
using DSharpPlus;
using DSharpPlus.EventArgs;

namespace DiscordBot {
	class DiscordPlugin {
		public string Command { get; protected set; }

		protected DiscordClient m_discordClient;

		public DiscordPlugin(DiscordClient a_discordClient) {
			m_discordClient = a_discordClient;
			a_discordClient.MessageCreated += OnMessageCreated;
		}

		public virtual async Task OnMessageCreated(MessageCreateEventArgs e) {
			await Task.FromResult(0);
		}

		public virtual void OnAudioPacketReceived(object a_sender, DiscordAudioPacketEventArgs a_eventArgs) {

		}

		public virtual void OnChannelCreated(object a_sender, ChannelCreateEventArgs a_eventArgs) {
		
		}
		
		public virtual void OnChannelDeleted(object a_sender, ChannelDeleteEventArgs a_eventArgs) {
		
		}
		
		public virtual void OnChannelUpdated(object a_sender, ChannelUpdateEventArgs a_eventArgs) {
		
		}
		
		public virtual void OnGuildCreated(object a_sender, GuildCreateEventArgs a_eventArgs) {
		
		}
		
		public virtual void OnGuildDeleted(object a_sender, GuildDeleteEventArgs a_eventArgs) {
		
		}
		
		public virtual void OnGuildMemberBanned(object a_sender, GuildBanAddEventArgs a_eventArgs) {
		
		}
		
		public virtual void OnGuildMemberUnbanned(object a_sender, GuildBanRemoveEventArgs a_eventArgs) {

		}

		public virtual void OnGuildMemberUpdated(object a_sender, GuildMemberUpdateEventArgs a_eventArgs) {
		
		}
		
		public virtual void OnGuildUpdated(object a_sender, GuildUpdateEventArgs a_eventArgs) {
		
		}
		
		public virtual void OnMentionReceived(object a_sender, MentionType a_eventArgs) {
		
		}
		
		public virtual void OnMessageDeleted(object a_sender, MessageDeleteEventArgs a_eventArgs) {
		
		}
		
		public virtual void OnMessageEdited(object a_sender, MessageUpdateEventArgs a_eventArgs) {
		
		}
		
		public virtual void OnMessageReceived(object a_sender, MessageCreateEventArgs a_eventArgs) {
		
		}
		
		public virtual void OnPresenceUpdated(object a_sender, PresenceUpdateEventArgs a_eventArgs) {
		
		}
		
		public virtual void OnRoleDeleted(object a_sender, GuildRoleDeleteEventArgs a_eventArgs) {
		
		}
		
		public virtual void OnRoleUpdated(object a_sender, GuildRoleUpdateEventArgs a_eventArgs) {
		
		}
		
		public virtual void OnUserAddedToServer(object a_sender, GuildMemberAddEventArgs a_eventArgs) {
		
		}
		
		public virtual void OnUserLeftVoiceChannel(object a_sender, VoiceServerUpdateEventArgs a_eventArgs) {
		
		}
		
		public virtual void OnUserRemovedFromServer(object a_sender, GuildMemberRemoveEventArgs a_eventArgs) {
		
		}
		
		public virtual void OnUserSpeaking(object a_sender, VoiceReceiveEventArgs a_eventArgs) {
		
		}

		public virtual void OnUserTypingStart(object a_sender, TypingStartEventArgs a_eventArgs) {

		}

		public virtual void OnUserUpdate(object a_sender, UserUpdateEventArgs a_eventArgs) {
		
		}
		
		public virtual void OnVoiceClientConnected(object a_sender, EventArgs a_eventArgs) {
		
		}
		
		public virtual void OnVoiceQueueEmpty(object a_sender, EventArgs a_eventArgs) {
		
		}
		
		public virtual void OnVoiceStateUpdate(object a_sender, VoiceStateUpdateEventArgs a_eventArgs) {
		
		}
	}
}
