import {
  HttpErrorResponse,
  HttpEvent,
  HttpHandler,
  HttpInterceptor,
  HttpRequest,
} from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, catchError, throwError } from 'rxjs';
import { MessageInfoService } from '../shared/services/message-info.service';

@Injectable()
export class HttpErrorInterceptor implements HttpInterceptor {
  constructor(private readonly messageInfoService: MessageInfoService) {}
  intercept(
    request: HttpRequest<any>,
    next: HttpHandler
  ): Observable<HttpEvent<any>> {
    return next.handle(request).pipe(
      catchError((error: HttpErrorResponse) => {
        // Handle the error
        console.log(error, 'error');
        if (error.message) {
          this.messageInfoService.showErrorMessage(error.message.toString());
        } else {
          this.messageInfoService.showErrorMessage(error.toString());
        }
        return throwError(error);
      })
    );
  }
}
