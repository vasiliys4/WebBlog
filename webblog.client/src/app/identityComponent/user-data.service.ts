import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import {User} from "./user";

@Injectable({ providedIn: 'root' })
export class UserDataService {
  private apiUrl = 'https://localhost:7236/api/user';

  constructor(private https: HttpClient) {}

  login(user: User): Observable<string> {
    return this.https.post<string>(this.apiUrl + "/login",{
      email: user.Email,
      password: user.Password,
    });
  }

  register(user: User): Observable<any> {
    return this.https.post(`${this.apiUrl}/register`, {
      UserName: user.UserName,
      Email: user.Email,
      PasswordHash: user.Password
    });
  }

  saveToken(token: string) {
    localStorage.setItem('auth_token', token);
  }

  getToken() {
    return localStorage.getItem('auth_token');
  }

  logout() {
    localStorage.removeItem('auth_token');
  }
  isLoggedIn(): boolean {
    return !!this.getToken();
  }
}

