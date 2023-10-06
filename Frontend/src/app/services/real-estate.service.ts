import { Injectable } from '@angular/core';
import { ApiService } from './api.service';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/envirionment';
import { RealEstateProject } from '../models/real-estate-project.model';
import { ApiQueryParam } from '../models/api-query-param.model';

@Injectable({
  providedIn: 'root',
})
export class RealEstateService {
  apiUrl: string = `${environment.BackendApiUrl}/RealEstate`;
  constructor(private apiService: ApiService) {}

  getAll(
    startDate?: string,
    endDate?: string,
    numberOfRecords?: number,
    isOnlyNewBuildings?: boolean,
    isOnlyLiked?: boolean,
    userId?: number
  ): Observable<RealEstateProject[]> {
    const params: ApiQueryParam[] = [
      { value: startDate, paramName: 'startDate' },
      { value: endDate, paramName: 'endDate' },
      {
        value: numberOfRecords ? `${numberOfRecords}` : numberOfRecords,
        paramName: 'numberOfRecords',
      },
      {
        value: isOnlyNewBuildings
          ? `${isOnlyNewBuildings}`
          : isOnlyNewBuildings,
        paramName: 'isOnlyNewBuildings',
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
    return this.apiService.get<RealEstateProject[]>(`${this.apiUrl}`, params);
  }

  removeById(id: number): Observable<void> {
    return this.apiService.delete<void>(`${this.apiUrl}/${id}`);
  }

  add(project: RealEstateProject): Observable<RealEstateProject> {
    return this.apiService.post<RealEstateProject>(`${this.apiUrl}`, project);
  }

  update(project: RealEstateProject): Observable<void> {
    return this.apiService.put(`${this.apiUrl}/${project.id}`, project);
  }
  
  getById(id: number): Observable<RealEstateProject> {
    return this.apiService.get<RealEstateProject>(`${this.apiUrl}/${id}`);
  }
}
