import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor
} from '@angular/common/http';
import { Observable } from 'rxjs';
import { OidcSecurityService } from 'angular-auth-oidc-client';
import { Environment } from '../index/constant.index';

@Injectable()
export class HttpTokenInterceptor implements HttpInterceptor {

  constructor(private authService: OidcSecurityService, private env: Environment) {
  }

  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
    // debugger;
    if (!request.url.startsWith(this.env.identityServerUrl)) {
      const token = this.authService.getToken();
      if (token) {
        request = request.clone({ setHeaders: { 'Authorization': `Bearer ${token}` } });
      }
    }
    return next.handle(request);
  }

}
