import { HomeApiServiceBase } from "./HomeApiServiceBase";

export class HomeApiService extends HomeApiServiceBase {
    constructor(token: string) {
        super(token);
    }

    refreshToken(token: string) {
        super.refreshToken(token);
        super.token = 'test';
    }

    retrieveDiscordToken() {
        super.retrieveDiscordToken();

        throw new Error("not Implemented");
    }
}