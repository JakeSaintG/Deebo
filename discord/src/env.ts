import dotenv from 'dotenv';
import fs from 'fs';
import { parseBool } from './utils/parseBool';

if (!fs.existsSync('./src/.env')) {
    console.log('Creating env file...');

    const devFile = fs.readFileSync('./src/.env.development', 'utf-8')
        .split(/\r?\n/)
        .filter((line: string) => !(line.charAt(0) === '#' && line.charAt(1) === '!'))
        .join('\n');

    fs.writeFileSync('./src/.env', devFile);

    console.log('.env file created!')
    console.log('Pulling discord token from .env file is not on by default.')
    console.log('If you would like to use .env as opposed to API calls, edit created .env file.')
}

dotenv.config({path: './src/.env'});

const TOKEN_FROM_ENV: boolean = parseBool(process.env.TOKEN_FROM_ENV?.trim().toLowerCase()) || false;
const DISCORD_TOKEN: string = TOKEN_FROM_ENV ? process.env.DISCORD_TOKEN || 'NOT_CONFIGURED' : 'USE_API';

export const Env = {
    TOKEN_FROM_ENV,
    DISCORD_TOKEN
} as const;
