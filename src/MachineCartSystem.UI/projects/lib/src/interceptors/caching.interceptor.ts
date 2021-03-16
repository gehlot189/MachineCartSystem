import {
  HttpEvent, HttpHandler,
  HttpInterceptor, HttpRequest
} from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable()
export class CachingInterceptor implements HttpInterceptor {

  constructor(private cache: RequestCache) { }

  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
    // if (!isCacheable(request)) {
    return next.handle(request);
    // }
  }
}
