import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { ApiResponse } from '../utils/api-response';
import { AppConfiguration } from './app-configuration';

@Injectable()
export class AppConfigService {
  private appConfig: AppConfiguration;

  constructor(private http: HttpClient) {
  }

  private loadAppConfig = (): Observable<any> => this.http.get('configuration/getConfig');

  getAppConfig = (): Promise<AppConfiguration> => {
    return this.loadAppConfig().pipe(map((response: ApiResponse) => {
      if (!response.isError) {
        this.appConfig = <AppConfiguration>response.result;
      }
      return this.appConfig;
    })).toPromise()
  }

}
