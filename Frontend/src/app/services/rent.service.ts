import { Injectable } from '@angular/core';
import { ApiService } from './api.service';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/envirionment';
import { RentProject } from '../models/rent-project.model';
import { ApiQueryParam } from '../models/api-query-param.model';

@Injectable({
  providedIn: 'root',
})
export class RentService {
  apiUrl: string = `${environment.BackendApiUrl}/Rent`;
  constructor(private apiService: ApiService) {}

  getAll(
    startDate?: string,
    endDate?: string,
    numberOfRecords?: number,
    isOnlyLiked?: boolean,
    userId?: number
  ): Observable<RentProject[]> {
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
    return this.apiService.get<RentProject[]>(`${this.apiUrl}`, params);
  }

  removeById(id: number): Observable<void> {
    return this.apiService.delete<void>(`${this.apiUrl}/${id}`);
  }

  add(project: RentProject): Observable<RentProject> {
    return this.apiService.post<RentProject>(`${this.apiUrl}`, project);
  }

  update(project: RentProject): Observable<RentProject> {
    return this.apiService.put<RentProject>(`${this.apiUrl}/${project.id}`, project);
  }

  getById(id: number): Observable<RentProject> {
    return this.apiService.get<RentProject>(`${this.apiUrl}/${id}`);
  }
}
