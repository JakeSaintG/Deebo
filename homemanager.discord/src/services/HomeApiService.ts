import { HomeApiServiceBase } from "./HomeApiServiceBase";

export class HomeApiService extends HomeApiServiceBase {
    constructor() {
        super();
    }

    refreshBotToken(token: string) {
        super.refreshBotToken(token);
        super.botToken = 'test';
    }

    retrieveBotToken() {
        super.retrieveBotToken();

        

        console.log('fetching token...')
    }

    refreshLeaderNodeIp(token: string) {
        super.refreshBotToken(token);
        super.leaderNodeIp = 'test';
    }

    retrieveLeaderNodeIp() {
        super.retrieveBotToken();
        console.log('fetching ip...')
    }
}
