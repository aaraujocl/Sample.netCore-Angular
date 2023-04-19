import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment.development';

@Injectable({
  providedIn: 'root',
})
export class LoginService {
  uriapi: string = environment.urlAuthentication;

  constructor(private httpClient: HttpClient) {}

  login(username: string, password: string) {
    const body = {
      userName: username,
      password: password,
    };
    const httpHeaders = new HttpHeaders().set(
      'Content-Type',
      'application/json'
    );
    const endpoint: any = this.uriapi + 'api/auth';
    return this.httpClient.post(endpoint, JSON.stringify(body), {
      headers: httpHeaders,
    });
  }
}
