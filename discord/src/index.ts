import { Env } from "./env";
import "reflect-metadata";
import { container } from 'tsyringe';
import { PingCommand } from './commands';
import { Client, GuildMember, PartialGuildMember, Role, GatewayIntentBits, Events } from "discord.js";
import { HomeApiService } from "./services/HomeApiService";

const homeApiService = new HomeApiService('kk');

let discordToken = Env.DISCORD_TOKEN_FROM_ENV ? Env.DISCORD_TOKEN : homeApiService.retrieveDiscordToken();

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

(async () => {
    let retries: number | null = null;

    do {
        console.log('Attemping Discord connection...')
            await client.login(discordToken)
                .then(() => console.log('Thumbs up emoji'))
                .catch(e => {
                    console.log(`retrying... ${e}`);

                    // TODO: settimeout and retry with current token
                    // TODO: after 2 failures with current token, retry with token from env

                    if (!retries) retries = 0;
                    retries++
                });
    } while (retries && retries < 3);

})()
