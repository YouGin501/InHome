import { Injectable } from '@angular/core';
import { environment } from 'src/environments/envirionment';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { UserService } from '../shared/services/user.service';
import { ApiService } from './api.service';
import { User } from '../models/user.model';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  apiUrl: string = `${environment.BackendApiUrl}/Users`;
  constructor(
    private readonly _http: HttpClient,
    private readonly apiService: ApiService
  ) {}

  login(login: string, password: string) {
    const headers = new HttpHeaders()
      .set('Access-Control-Allow-Origin', '*')
      .set('Content-Type', 'application/json')
      .set('Accept', '*/*');
    return this._http.post(
      `${this.apiUrl}/Login`,
      { login, password },
      {
        headers: headers,
      }
    );
  }

  registrate(
    login: string,
    password: string,
    name: string,
    surname: string,
    userType: number
  ) {
    const headers = new HttpHeaders()
      .set('Access-Control-Allow-Origin', '*')
      .set('Content-Type', 'application/json')
      .set('Accept', '*/*');
    return this._http.post(
      `${this.apiUrl}/Registration`,
      {
        id: 0,
        email: login,
        password,
        name,
        surname,
        userType,
      },
      {
        headers: headers,
      }
    );
  }

  getUser(id: number): Observable<User> {
    const headers = new HttpHeaders()
      .set('Access-Control-Allow-Origin', '*')
      .set('Content-Type', 'application/json')
      .set('Accept', '*/*');
    return this.apiService.get<User>(`${this.apiUrl}/${id}`);
  }

  updateUser(user: User, id: number): Observable<object>  {
    return this._http.put(`${this.apiUrl}/${id}`, {...user});
  }
}
