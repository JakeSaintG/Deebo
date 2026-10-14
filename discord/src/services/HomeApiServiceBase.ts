export class HomeApiServiceBase {
    private _discordToken: string = '';

    get discordToken(): string {
        return this._discordToken;
    }

    set discordToken(value: string) {
        this._discordToken = value;
    }
    
    constructor() {}

    notConfiguredEarlyReturn = () => {
        if (!this.discordToken) return;
    }

    refreshToken(token: string) {
        this.notConfiguredEarlyReturn();
    }

    retrieveDiscordToken() {
        this.notConfiguredEarlyReturn();
    }
}