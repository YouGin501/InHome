import { Injectable } from '@angular/core';
import { ApiService } from './api.service';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/envirionment';
import { ApiQueryParam } from '../models/api-query-param.model';
import { Post } from '../models/post.model';
import { Like } from '../models/like.model';

@Injectable({
  providedIn: 'root',
})
export class LikeService {
  apiUrl: string = `${environment.BackendApiUrl}/Likes`;
  constructor(private apiService: ApiService) {}

  getLikesForUser(userId: number): Observable<Like[]> {
    const params: ApiQueryParam[] = [{ value: userId, paramName: 'userId' }];
    return this.apiService.get<Like[]>(
      `${this.apiUrl}`,
      params
    );
  }

  addLike(like: Like): Observable<Like>{
    return this.apiService.post<Like>(
      `${this.apiUrl}`,
      like
    );
  }
}
