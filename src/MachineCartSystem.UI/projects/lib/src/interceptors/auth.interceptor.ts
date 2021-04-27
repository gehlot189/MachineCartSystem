import {
  HttpEvent, HttpHandler,

  HttpInterceptor, HttpRequest
} from '@angular/common/http';
import { Injectable } from '@angular/core';
import { OidcSecurityService } from 'angular-auth-oidc-client';
import { Observable } from 'rxjs';
import { Environment } from '../index/constant.index';

@Injectable()
export class AuthInterceptor implements HttpInterceptor {

  constructor(private authService: OidcSecurityService, private env: Environment) {
  }

  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
    // debugger;
    if (!request.url.startsWith(this.env.identityServerUrl)) {
      let token = this.authService.getToken();
      if (token) {
        request = request.clone({ setHeaders: { 'Authorization': `Bearer ${token}` } });
      }
    }
    return next.handle(request);
  }

}
