import { Injectable } from '@angular/core';
import { ApiService } from './api.service';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/envirionment';
import { ResidentialComplexProject } from '../models/residential-complex-project.model';
import { ApiQueryParam } from '../models/api-query-param.model';

@Injectable({
  providedIn: 'root',
})
export class ResidentialComplexService {
  apiUrl: string = `${environment.BackendApiUrl}/ResidentialComplex`;
  constructor(private apiService: ApiService) {}

  getAll(userId?: number): Observable<ResidentialComplexProject[]> {
    const params: ApiQueryParam[] = [
      {
        value: userId ? `${userId}` : userId,
        paramName: 'userId',
      },
    ];
    return this.apiService.get<ResidentialComplexProject[]>(`${this.apiUrl}`, params);
  }

  removeById(id: number): Observable<void> {
    return this.apiService.delete<void>(`${this.apiUrl}/${id}`);
  }

  add(
    project: ResidentialComplexProject
  ): Observable<ResidentialComplexProject> {
    project.id = 0;
    return this.apiService.post<ResidentialComplexProject>(
      `${this.apiUrl}`,
      project
    );
  }

  update(
    project: ResidentialComplexProject
  ): Observable<ResidentialComplexProject> {
    return this.apiService.put<ResidentialComplexProject>(
      `${this.apiUrl}/${project.id}`,
      project
    );
  }
}
