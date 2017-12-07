import { Injectable } from '@angular/core';
import { RegisterUser } from '../models/RegisterUser';
import { Http } from '@angular/http';

const Api_Url = 'http://localhost:50370/api';
@Injectable()
export class AuthService {

  constructor(private _http: Http) { }

  register(regUserData: RegisterUser) {
    return this._http.post(`${Api_Url}/Register`, regUserData);
  }
}
