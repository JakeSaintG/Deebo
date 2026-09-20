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

// move to utils
const delay = (t: number) => new Promise(resolve => setTimeout(resolve, t));

const retryAmount = Env.DISCORD_TOKEN_FROM_ENV ? 2 : 4;
let backoff = 400;
(async () => {
    let retries: number | null = null;

    do {
        console.log('Attemping Discord connection...')
            await client.login('discordToken')
                .then(() => console.log('Thumbs up emoji'))
                .catch(async e => {
                    await delay(backoff);
                    console.log(`retrying... ${e}`);
                    backoff = backoff*2;

                    if (retries && retries >= 3) discordToken = Env.DISCORD_TOKEN;
                    if (!retries) retries = 0;
                    retries++
                });
    } while (retries && retries < retryAmount);

    if (retries == retryAmount) {
        console.log('failed to connect to Discord bot. Exiting...');
        process.exit(1);
    }
})()
