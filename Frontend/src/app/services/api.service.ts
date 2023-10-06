import { HttpClient, HttpHeaders, HttpResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { tap } from 'rxjs/operators';
import { ApiQueryParam } from '../models/api-query-param.model';

@Injectable({
  providedIn: 'root',
})
export class ApiService {
  constructor(private _http: HttpClient) {}

  get<Type>(apiUrl: string, params?: ApiQueryParam[]): Observable<Type> {
    let queryString = '?';
    params?.forEach((param) => {
      if (param.value) {
        queryString += `${param.paramName}=${param.value}&`;
      }
    });
    const headers = new HttpHeaders()
      .set('Access-Control-Allow-Origin', '*')
      .set('Content-Type', 'application/json')
      .set('Accept', '*/*');
    return this._http.get<Type>(`${apiUrl}${params ? queryString : ''}`, {
      headers: headers,
    });
  }

  delete<Type>(apiUrl: string): Observable<Type> {
    const headers = new HttpHeaders()
      .set('Content-Type', 'application/json')
      .set('Accept', '*/*');
    return this._http.delete<Type>(apiUrl, { headers: headers });
  }

  post<Type>(
    apiUrl: string,
    entity: any,
    params?: ApiQueryParam[]
  ): Observable<Type> {
    let queryString = '?';
    params?.forEach((param) => {
      if (param.value) {
        queryString += `${param.paramName}=${param.value}&`;
      }
    });
    const headers = new HttpHeaders()
      .set('Content-Type', 'application/json')
      .set('Accept', '*/*');
    return this._http.post<Type>(
      `${apiUrl}${params ? queryString : ''}`, entity, { headers: headers }
    );
  }

  put<Type>(apiUrl: string, entity: any): Observable<Type> {
    const headers = new HttpHeaders()
      .set('Content-Type', 'application/json')
      .set('Accept', '*/*');
    return this._http.put<Type>(apiUrl, entity, { headers: headers });
  }
}
