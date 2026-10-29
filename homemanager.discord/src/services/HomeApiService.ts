import { HomeApiServiceBase } from "./HomeApiServiceBase";

export class HomeApiService extends HomeApiServiceBase {
    constructor() {
        super();
    }

    refreshToken(token: string) {
        super.refreshToken(token);
        super.botToken = 'test';
    }

    retrieveToken() {
        super.retrieveToken();
        console.log('fetching token...')
    }

    refreshLeaderNodeIp(token: string) {
        super.refreshToken(token);
        super.leaderNodeIp = 'test';
    }

    retrieveLeaderNodeIp() {
        super.retrieveToken();
        console.log('fetching ip...')
    }
}
