export class HomeApiServiceBase {
    private _token: string = '';

    get token(): string {
        return this._token;
    }

    set token(value: string) {
        this._token = value;
    }
    
    constructor(token: string) {
        this.token = token;
    }

    notConfiguredEarlyReturn = () => {
        if (!this.token) return;
    }

    refreshToken(token: string) {
        this.notConfiguredEarlyReturn();
    }

    retrieveDiscordToken() {
        this.notConfiguredEarlyReturn();
    }
}