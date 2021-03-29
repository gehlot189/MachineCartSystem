import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { OpenIdConfiguration } from 'angular-auth-oidc-client';
import { StatusCodes } from 'http-status-codes';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { ApiResponse } from '../utils/api-response';

@Injectable()
export class AppConfigService {
  private appConfig: OpenIdConfiguration;

  constructor(private http: HttpClient) {
  }

  private loadAppConfig = (): Observable<any> => this.http.get('configuration/getConfig');

  getAppConfig = (): Promise<OpenIdConfiguration> => {
    return this.loadAppConfig().pipe(map((response: ApiResponse) => {
      this.appConfig = <OpenIdConfiguration>response.result;
      if (!response.isError && response.statusCode == StatusCodes.OK) {
        this.appConfig = <OpenIdConfiguration>response.result;
      }
      return this.appConfig;
    })).toPromise()
  }

}
