import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { OpenIdConfiguration } from 'angular-auth-oidc-client';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Injectable()
export class AppConfigService {
  private appConfig: OpenIdConfiguration;

  constructor(private http: HttpClient) {
  }

  loadAppConfig = (): Observable<void> => {
    return this.http.get('configuration/getConfig').pipe(map(() => null));
  }

  getAppConfig = () => {
    return this.appConfig;
  }

}
