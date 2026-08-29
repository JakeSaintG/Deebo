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

client.on(Events.InteractionCreate, async interaction => {
    try {
        if (!interaction.isCommand()) return;
        const Command = commandsMap[interaction.commandName];
        if (!Command) return;
        
        const CommandClass = new Command(interaction, container);
        await CommandClass.execute();
    } catch (error) {
        // handleInteractionError(error, interaction)
    }
});

client.login(Env.DISCORD_TOKEN);
