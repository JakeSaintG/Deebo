import { HomeApiServiceBase } from "./HomeApiServiceBase";

export class HomeApiService extends HomeApiServiceBase {
    constructor() {
        super();
    }

    refreshToken(token: string) {
        super.refreshToken(token);
        super.discordToken = 'test';
    }

    retrieveDiscordToken() {
        super.retrieveDiscordToken();
        console.log('fetching token...')
    }
}
