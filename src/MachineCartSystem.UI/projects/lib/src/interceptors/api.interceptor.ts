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
      //  debugger;
      if (request.url.startsWith("configuration/getConfig"))
        request = request.clone({ url: this.env.apiUrl + request.url });
      else
        request = request.clone({ url: request.url });
    }
    return next.handle(request);
  }
}
