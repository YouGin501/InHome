import { Injectable } from '@angular/core';
import { ApiService } from './api.service';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/envirionment';
import { ApiQueryParam } from '../models/api-query-param.model';
import { Feedback } from '../models/feedback.model';

@Injectable({
  providedIn: 'root',
})
export class FeedbackService {
  apiUrl: string = `${environment.BackendApiUrl}/Feedbacks`;
  constructor(private apiService: ApiService) {}

  getAll(userId: number): Observable<Feedback[]> {
    const params: ApiQueryParam[] = [
      { value: userId, paramName: 'writtenForUserId' },
    ];
    return this.apiService.get<Feedback[]>(`${this.apiUrl}`, params);
  }

  add(feedback: Feedback): Observable<void> {
    feedback.id = 0;
    return this.apiService.post(`${this.apiUrl}`, feedback);
  }
}
