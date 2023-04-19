export class Session {
  public token: string = '';
  public user: any;

  constructor(json: any = null) {
    if (json !== null) {
      this.token = json.token;
      this.user = json.user;
    }
  }
}
