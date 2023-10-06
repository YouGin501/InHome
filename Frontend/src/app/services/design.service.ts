import { Injectable } from '@angular/core';
import {ApiService} from './api.service';
import {Observable} from 'rxjs';
import { environment } from 'src/environments/envirionment';
import { DesignProject } from '../models/design-project.model';
import { ApiQueryParam } from '../models/api-query-param.model';

@Injectable({
  providedIn: 'root',
})
export class DesignService {

  apiUrl: string = `${environment.BackendApiUrl}/Design`;
  constructor(private apiService: ApiService) { }

  getAll(startDate?: string, endDate?: string, numberOfRecords?: number, isOnlyLiked?: boolean, userId?: number): Observable<DesignProject[]> {
    const params: ApiQueryParam[] = [
      { value: startDate, paramName: 'startDate' },
      { value: endDate, paramName: 'endDate' },
      {
        value: numberOfRecords ? `${numberOfRecords}` : numberOfRecords,
        paramName: 'numberOfRecords',
      },
      {
        value: isOnlyLiked ? `${isOnlyLiked}` : isOnlyLiked,
        paramName: 'isOnlyLiked',
      },
      {
        value: userId ? `${userId}` : userId,
        paramName: 'userId',
      },
    ];
    return this.apiService.get<DesignProject[]>(`${this.apiUrl}`, params);
  }

  removeById(id: number): Observable<void> {
    return this.apiService.delete<void>(`${this.apiUrl}/${id}`);
  }

  add(project: DesignProject): Observable<void> {
    project.id = 0;
    return this.apiService.post(`${this.apiUrl}`, project);
  }

  update(project: DesignProject): Observable<void> {
    return this.apiService.put(`${this.apiUrl}/${project.id}`, project);
  }

}