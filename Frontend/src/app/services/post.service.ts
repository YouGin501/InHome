import { Injectable } from '@angular/core';
import { ApiService } from './api.service';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/envirionment';
import { ApiQueryParam } from '../models/api-query-param.model';
import { Post } from '../models/post.model';
import { UserType } from '../models/user.model';

@Injectable({
  providedIn: 'root',
})
export class PostService {
  apiUrl: string = `${environment.BackendApiUrl}/Post`;
  constructor(private apiService: ApiService) {}

  getPostsForUser(
    userId: number,
    country: string,
    userType: UserType
  ): Observable<Post[]> {
    const params: ApiQueryParam[] = [
      { value: userId, paramName: 'userId' },
      {
        value: country === 'All' ? undefined : country,
        paramName: 'country',
      },
      { value: userType === 0 ? undefined : userType, paramName: 'userType' },
    ];
    return this.apiService.get<Post[]>(
      `${this.apiUrl}/GetPostsForUser`,
      params
    );
  }

  getAllPosts(
    userId: number,
  ): Observable<Post[]> {
    const params: ApiQueryParam[] = [
      { value: userId, paramName: 'userId' },
    ];
    return this.apiService.get<Post[]>(
      `${this.apiUrl}`,
      params
    );
  }

  createPost(post: Post): Observable<Post> {
    return this.apiService.post<Post>(`${this.apiUrl}`, post);
  }
}
