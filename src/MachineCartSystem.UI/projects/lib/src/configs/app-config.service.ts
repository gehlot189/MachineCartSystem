import { HttpBackend, HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { AbstractSecurityStorage } from 'angular-auth-oidc-client';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { Environment } from '../environments/environment';
import { ApiResponse } from '../public-api';
import { AppConfiguration } from './app-configuration';

@Injectable()
export class AppConfigService {
  private appConfig: AppConfiguration;
  private httpClient: HttpClient;

  constructor(private handler: HttpBackend, private env: Environment, private storage: AbstractSecurityStorage) {
    this.httpClient = new HttpClient(handler);
  }

  private loadAppConfig = (): Observable<any> => this.httpClient.get(this.env.gatewayUrl + 'configuration/getConfig');

  getAppConfig = (): Promise<AppConfiguration> => {
    return this.loadAppConfig().pipe(map((response: ApiResponse) => {
      if (!response.isError) {
        this.appConfig = <AppConfiguration>response.result;
        this.storage.write('gatewayUrl', this.env.gatewayUrl);
      }
      return this.appConfig;
    })).toPromise();
  }
}
