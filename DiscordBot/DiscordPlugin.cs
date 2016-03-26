using System;
using DiscordSharp;
using DiscordSharp.Events;

namespace DiscordBot {
	class DiscordPlugin {
		public string Command { get; protected set; }

		protected DiscordMain m_discordMain;

		public DiscordPlugin(DiscordMain a_discordMain) {
			m_discordMain = a_discordMain;
		}

		public virtual void onAudioPacketReceived(object a_sender, DiscordAudioPacketEventArgs a_eventArgs) {

		}

		public virtual void onBanRemoved(object a_sender, DiscordBanRemovedEventArgs a_eventArgs) {
		
		}
		
		public virtual void onChannelCreated(object a_sender, DiscordChannelCreateEventArgs a_eventArgs) {
		
		}
		
		public virtual void onChannelDeleted(object a_sender, DiscordChannelDeleteEventArgs a_eventArgs) {
		
		}
		
		public virtual void onChannelUpdated(object a_sender, DiscordChannelUpdateEventArgs a_eventArgs) {
		
		}
		
		public virtual void onConnected(object a_sender, DiscordConnectEventArgs a_eventArgs) {
		
		}
		
		public virtual void onGuildCreated(object a_sender, DiscordGuildCreateEventArgs a_eventArgs) {
		
		}
		
		public virtual void onGuildDeleted(object a_sender, DiscordGuildDeleteEventArgs a_eventArgs) {
		
		}
		
		public virtual void onGuildMemberBanned(object a_sender, DiscordGuildBanEventArgs a_eventArgs) {
		
		}
		
		public virtual void onGuildMemberUpdated(object a_sender, DiscordGuildMemberUpdateEventArgs a_eventArgs) {
		
		}
		
		public virtual void onGuildUpdated(object a_sender, DiscordServerUpdateEventArgs a_eventArgs) {
		
		}
		
		public virtual void onKeepAliveSent(object a_sender, DiscordKeepAliveSentEventArgs a_eventArgs) {
		
		}
		
		public virtual void onMentionReceived(object a_sender, DiscordMessageEventArgs a_eventArgs) {
		
		}
		
		public virtual void onMessageDeleted(object a_sender, DiscordMessageDeletedEventArgs a_eventArgs) {
		
		}
		
		public virtual void onMessageEdited(object a_sender, DiscordMessageEditedEventArgs a_eventArgs) {
		
		}
		
		public virtual void onMessageReceived(object a_sender, DiscordMessageEventArgs a_eventArgs) {
		
		}
		
		public virtual void onPresenceUpdated(object a_sender, DiscordPresenceUpdateEventArgs a_eventArgs) {
		
		}
		
		public virtual void onPrivateChannelCreated(object a_sender, DiscordPrivateChannelEventArgs a_eventArgs) {
		
		}
		
		public virtual void onPrivateChannelDeleted(object a_sender, DiscordPrivateChannelDeleteEventArgs a_eventArgs) {
		
		}
		
		public virtual void onPrivateMessageDeleted(object a_sender, DiscordPrivateMessageDeletedEventArgs a_eventArgs) {
		
		}
		
		public virtual void onPrivateMessageReceived(object a_sender, DiscordPrivateMessageEventArgs a_eventArgs) {
		
		}
		
		public virtual void onRoleDeleted(object a_sender, DiscordGuildRoleDeleteEventArgs a_eventArgs) {
		
		}
		
		public virtual void onRoleUpdated(object a_sender, DiscordGuildRoleUpdateEventArgs a_eventArgs) {
		
		}
		
		public virtual void onSocketClosed(object a_sender, DiscordSocketClosedEventArgs a_eventArgs) {
		
		}
		
		public virtual void onSocketOpened(object a_sender, EventArgs a_eventArgs) {
		
		}
		
		public virtual void onTextClientDebugMessageReceived(object a_sender, LoggerMessageReceivedArgs a_eventArgs) {
		
		}
		
		public virtual void onUnknownMessageTypeReceived(object a_sender, UnknownMessageEventArgs a_eventArgs) {
		
		}
		
		public virtual void onURLMessageAutoUpdate(object a_sender, DiscordURLUpdateEventArgs a_eventArgs) {
		
		}
		
		public virtual void onUserAddedToServer(object a_sender, DiscordGuildMemberAddEventArgs a_eventArgs) {
		
		}
		
		public virtual void onUserLeftVoiceChannel(object a_sender, DiscordLeftVoiceChannelEventArgs a_eventArgs) {
		
		}
		
		public virtual void onUserRemovedFromServer(object a_sender, DiscordGuildMemberRemovedEventArgs a_eventArgs) {
		
		}
		
		public virtual void onUserSpeaking(object a_sender, DiscordVoiceUserSpeakingEventArgs a_eventArgs) {
		
		}
		public virtual void onUserTypingStart(object a_sender, DiscordTypingStartEventArgs a_eventArgs) {

		}

		public virtual void onUserUpdate(object a_sender, DiscordUserUpdateEventArgs a_eventArgs) {
		
		}
		
		public virtual void onVoiceClientConnected(object a_sender, EventArgs a_eventArgs) {
		
		}
		
		public virtual void onVoiceClientDebugMessageReceived(object a_sender, LoggerMessageReceivedArgs a_eventArgs) {
		
		}
		
		public virtual void onVoiceQueueEmpty(object a_sender, EventArgs a_eventArgs) {
		
		}
		
		public virtual void onVoiceStateUpdate(object a_sender, DiscordVoiceStateUpdateEventArgs a_eventArgs) {
		
		}
	}
}
