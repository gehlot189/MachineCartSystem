import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest, HttpResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { tap } from 'rxjs/operators';
import { LoggingService } from '../logger/logging.service';

@Injectable()
export class LoggingInterceptor implements HttpInterceptor {
  private started: number;

  constructor(private logService: LoggingService) { }

  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
    this.started = Date.now();

    return next.handle(request).pipe(tap(event => {
      if (event instanceof HttpResponse)
        this.logService.logInfo(this.elapsedTime(request, 'success'));
    }, (err) => {
      this.logService.logInfo(this.elapsedTime(request, 'fail'));
      this.logService.logError('error: ' + JSON.stringify(err));
    }));
  }

  private elapsedTime = (request: any, status: string): string => {
    const elapsed = ((Date.now() - this.started) / 1000).toFixed(3);
    const msg = `${request.method} "${request.urlWithParams}" ${status} in ${elapsed} second(s).`;
    return msg;
  }
}
