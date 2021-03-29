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
    // debugger;
    if (!request.url.startsWith(this.env.identityServerUrl)) {
      request = request.clone({ url: this.env.apiUrl + request.url });
    }
    return next.handle(request);
  }
}
