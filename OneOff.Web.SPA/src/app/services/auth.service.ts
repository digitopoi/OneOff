import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import 'rxjs/add/operator/filter';
import * as auth0 from 'auth0-js';

const Api_Url = 'http://kcpelevennoteapie.azurewebsites.net';
@Injectable()
export class AuthService {

  auth0 = new auth0.WebAuth({
    clientID: 'tAjGawAUTgk7Ea5KdOfL6elL7pMgfjDq',
    domain: 'one-off.auth0.com',
    responseType: 'token id_token',
    audience: 'https://one-off.auth0.com/userinfo',
    redirectUri: 'http://localhost:4200/artist',
    scope: 'openid'
  });

  constructor(public router: Router) { }

  public login(): void {
    this.auth0.authorize();
  }

}
