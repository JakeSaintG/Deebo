import { Env } from "./env";
import { container } from 'tsyringe';
import { PingCommand } from './commands';
import { Client, GuildMember, PartialGuildMember, Role, GatewayIntentBits, Events } from "discord.js";

const commandsMap: Record<string, any> = {
    ping: PingCommand,
    // server: ServerCommand,
    // set_welcome: SetWelcomeCommand,
    // reaction: ReactionCommand
}

const client = new Client({ intents: [GatewayIntentBits.Guilds] });

client.on(Events.ClientReady, (readyClient) => {
    console.log(`Logged in as ${readyClient.user.tag}!`);
});

client.login(Env.DISCORD_TOKEN);
