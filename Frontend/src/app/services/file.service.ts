import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/envirionment';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Document } from '../models/document.model';

@Injectable({
  providedIn: 'root',
})
export class FileService {
  apiUrl: string = `${environment.BackendApiUrl}/Files`;
  constructor(private _http: HttpClient) {}

  uploadFiles(files: FormData, userId: number): Observable<object> {
    const headers = new HttpHeaders().set(
      'Content-Type',
      'multipart/form-data'
    );

    const params = new HttpParams().set('userId', userId);
    return this._http.post(this.apiUrl, files, { params });
  }

  deleteFiles(documents: Document[], userId: number): Observable<object> {
    const headers = new HttpHeaders().set('Content-Type', 'application/json');

    const options = {
      headers: headers,
      body: {
        documents: documents,
      },
    };
    return this._http.delete(`${this.apiUrl}/${userId}`, options);
  }

  updateUserPhoto(photo: FormData, userId: number): Observable<object> {
    return this._http.post(`${this.apiUrl}/updateUserPhoto/${userId}`, photo);
  }

  addPostPhoto(photos: FormData, postId: number): Observable<object> {
    return this._http.post(`${this.apiUrl}/addPostPhotos/${postId}`, photos);
  }

  addRentPhoto(photos: FormData, postId: number): Observable<object> {
    return this._http.post(`${this.apiUrl}/addRentPhotos/${postId}`, photos);
  }

  addRealEstatePhoto(photos: FormData, postId: number): Observable<object> {
    return this._http.post(
      `${this.apiUrl}/addRealEstatePhotos/${postId}`,
      photos
    );
  }

  addResedentialComplexPhoto(photos: FormData, postId: number): Observable<object> {
    return this._http.post(
      `${this.apiUrl}/addResedentialComplexPhotos/${postId}`,
      photos
    );
  }
}
