import { Inject, Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor
} from '@angular/common/http';
import { Observable } from 'rxjs';
import { Environment } from '../index/constant.index';

@Injectable()
export class ApiPrefixInterceptor implements HttpInterceptor {

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
