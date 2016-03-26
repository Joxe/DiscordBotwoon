using DiscordSharp;
using DiscordSharp.Objects;
using System;

namespace DiscordBot {
	public interface Command {
		void execute(DiscordClient client, DiscordChannel channel, DiscordMember user, string parameters);
	}
}

