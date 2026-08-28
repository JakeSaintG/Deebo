import { Interaction } from 'discord.js';
import { SlashCommandBuilder } from '@discordjs/builders';

export const getData = (): SlashCommandBuilder => {
    const builder = new SlashCommandBuilder();
    return builder
        .setName('ping')
        .setDescription('Replies with current online status of HomeBot.');
};

export default class PingCommand {
    protected interaction: Interaction;

    constructor(interaction: Interaction) {
        this.interaction = interaction;
    }

    public execute = async (): Promise<void> => {
        if (!this.interaction.isCommand()) return;

        await this.interaction.reply('HomeBot is online!');
    };
}