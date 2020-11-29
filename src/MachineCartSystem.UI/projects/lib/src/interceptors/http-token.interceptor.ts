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
      const headersConfig = {
        'Content-Type': 'application/json',
        'Accept': 'application/json',
        'Authorization': `Bearer ${token}`
      };
      if (token) {
        request = request.clone({ setHeaders: headersConfig });
      }
    }
    return next.handle(request);
  }

}
