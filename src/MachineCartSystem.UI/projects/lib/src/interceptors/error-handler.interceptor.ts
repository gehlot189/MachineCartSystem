import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { StatusCodes } from 'http-status-codes';
import { Observable } from 'rxjs';
import { tap } from 'rxjs/operators';
import { ComponentConstant } from '../index/constant.index';
import { LoggingService } from './../logger/logging.service';

@Injectable()
export class ErrorHandlerInterceptor implements HttpInterceptor {

  constructor(private logService: LoggingService,
    private router: Router) {
  }

  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
    // debugger;
    return next.handle(request).pipe(tap(_ => _, (err) => this.errorHandler(err)));
  }

  private errorHandler = (response: HttpEvent<any>) => {
    const httpErrorCode = response['status'] as StatusCodes;
    switch (httpErrorCode) {
      case StatusCodes.UNAUTHORIZED:
        //  this.alertService.showMessage('response', 'Error', MessageSeverity.error);
        this.router.navigateByUrl(ComponentConstant.Login);
        break;
      case StatusCodes.FORBIDDEN:
        // this.router.navigateByUrl('/auth/403');
        //   this.alertService.showMessage('response', 'Error', MessageSeverity.error);
        this.router.navigateByUrl(ComponentConstant.Login);
        break;
      default:
      // this.alertService.showMessage('response', 'Error', MessageSeverity.error);
    }
    // this.alertService.showMessage('response', 'Error', MessageSeverity.error);
  }
}
