export class HomeApiServiceBase {
    // TODO: store other node IPs
    // In case the leader goes down but not the bot, it may need to go fishing for a new leader
    
    private _botToken: string = '';

    get botToken(): string {
        return this._botToken;
    }

    set botToken(value: string) {
        this._botToken = value;
    }

    private _leaderNodeIp: string = '';

    get leaderNodeIp(): string {
        return this._leaderNodeIp;
    }

    set leaderNodeIp(value: string) {
        this._leaderNodeIp = value;
    }
    
    constructor() {}

    tokenNotConfiguredEarlyReturn = () => {
        if (!this.botToken) return;
    }

    refreshToken(token: string) {
        this.tokenNotConfiguredEarlyReturn();
    }

    retrieveToken() {
        this.tokenNotConfiguredEarlyReturn();
    }


    refreshLeaderNodeIp(token: string) {
        this.tokenNotConfiguredEarlyReturn();
    }

    retrieveLeaderNodeIp() {
        this.tokenNotConfiguredEarlyReturn();
    }
}