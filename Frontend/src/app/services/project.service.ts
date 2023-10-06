import { Injectable } from '@angular/core';
import { ApiService } from './api.service';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/envirionment';
import { ApiQueryParam } from '../models/api-query-param.model';
import { Post } from '../models/post.model';
import { Project } from '../models/project.model';

@Injectable({
  providedIn: 'root',
})
export class ProjectService {
  apiUrl: string = `${environment.BackendApiUrl}/Projects`;
  constructor(private apiService: ApiService) {}

  getAllProjectsFromSubscriptions(number: number, userId: number): Observable<Project[]> {
    const params: ApiQueryParam[] = [
      { value: number, paramName: 'number' },
      { value: userId, paramName: 'subscribedUserId' },
    ];
    return this.apiService.get<Project[]>(
      `${this.apiUrl}/GetAllProjectsFromSubscriptions`,
      params
    );
  }
}
