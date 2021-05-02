import {
  HttpEvent, HttpHandler,

  HttpInterceptor, HttpRequest
} from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Environment } from '../index/constant.index';

@Injectable()
export class ApiInterceptor implements HttpInterceptor {

  constructor(private env: Environment) {
  }

  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
    if (!request.url.startsWith('http'))
      request = request.clone({ url: this.env.gatewayUrl + request.url });
    return next.handle(request);
  }
}
