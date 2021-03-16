import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class AppConfigService {
  private appConfig;

  constructor(private http: HttpClient) {
  }

  loadAppConfig = (): Promise<void> => {
    return this.http.get('/').toPromise().then(p => {
      this.appConfig = p;
    });
  }

  getAppConfig = () => {
    return this.appConfig;
  }

}
