import { Injectable } from '@angular/core';

@Injectable()
export class UserService {
  private _user: any;

  constructor() {
  }

  public get user(): any {
    return this._user;
  }
  public set user(v: any) {
    this._user = v;
  }
}
