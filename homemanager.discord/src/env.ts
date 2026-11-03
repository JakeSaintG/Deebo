import dotenv from 'dotenv';
import fs from 'fs';
import { parseBool, testUuid } from './utils';
import { randomUUID, UUID } from 'crypto';
import os from 'os';

if (!fs.existsSync('./src/.env')) {
    console.log('Creating env file...');

    const devFile = fs.readFileSync('./src/.env.development', 'utf-8')
        .split(/\r?\n/)
        .filter((line: string) => !(line.charAt(0) === '#' && line.charAt(1) === '!'))
        .join('\n')

    fs.writeFileSync('./src/.env', devFile);

    console.log('.env file created!')
    console.log('Pulling discord token from .env file is not on by default.')
    console.log('If you would like to use .env as opposed to API calls, edit created .env file.')
}

dotenv.config({path: './src/.env'});

const DISCORD_TOKEN_FROM_ENV: boolean = parseBool(process.env.DISCORD_TOKEN_FROM_ENV?.trim().toLowerCase()) || false;
const DISCORD_TOKEN: string = DISCORD_TOKEN_FROM_ENV ? process.env.DISCORD_TOKEN || 'NOT_CONFIGURED' : 'USE_API';
const HOME_API_TOKEN: string = DISCORD_TOKEN_FROM_ENV ? process.env.HOME_API_TOKEN || 'NOT_CONFIGRED' : 'ERROR';
let BOT_ID: string = process.env.BOT_ID?.trim() || 'NOT_YET_CREATED';

if (BOT_ID == 'NOT_YET_CREATED' || !(testUuid(BOT_ID)) ) {
    BOT_ID = randomUUID();
    console.log(`Bot id created: ${BOT_ID}`)

    const envFileLines: string[] = fs.readFileSync('./src/.env', 'utf-8').split(os.EOL);

    const botIdLine = envFileLines.find((line: string) => line.match(new RegExp('BOT_ID')))

    if (botIdLine) {
        const target: number = envFileLines.indexOf(botIdLine);
        envFileLines.splice(target, 1, `BOT_ID='${BOT_ID}'`);
        fs.writeFileSync("./src/.env", envFileLines.join(os.EOL));
    } else {
        fs.appendFileSync("./src/.env", `BOT_ID='${BOT_ID}'`);
    }
}

// TODO: re-add this once I set auth set up
// if (HOME_API_TOKEN == 'ERROR') throw Error('ERROR CONFIGURING ENV');

export const Env = {
    DISCORD_TOKEN_FROM_ENV,
    HOME_API_TOKEN,
    DISCORD_TOKEN,
    BOT_ID
} as const;
