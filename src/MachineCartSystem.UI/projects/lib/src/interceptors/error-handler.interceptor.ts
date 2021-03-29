import { LoggingService } from './../logger/logging.service';
import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor
} from '@angular/common/http';
import { Observable } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { StatusCodes } from 'http-status-codes';
import { Router } from '@angular/router';
import { ComponentConstant, Environment } from '../index/constant.index';

@Injectable()
export class ErrorHandlerInterceptor implements HttpInterceptor {

  constructor(private env: Environment,
    private logService: LoggingService,
    private router: Router) {
  }

  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
    return next.handle(request).pipe(catchError(err => this.erroHandler(err)));
  }

  private erroHandler = (response: HttpEvent<any>): Observable<HttpEvent<any>> => {
    debugger;
    if (!this.env.production) {
      this.logService.logError('Request error ' + JSON.stringify(response));
    }
    const httpErrorCode = response['status'];
    switch (httpErrorCode) {
      case StatusCodes.UNAUTHORIZED:
        this.router.navigateByUrl(ComponentConstant.Login);
        break;
      case StatusCodes.FORBIDDEN:
        // this.router.navigateByUrl('/auth/403');
        this.router.navigateByUrl(ComponentConstant.Login);
        break;
      case StatusCodes.BAD_REQUEST:
        //  this.showError(error.message);
        break;
      default:
      //this.toasterService.pop('error', appToaster.errorHead, response['message']);
    }
    throw response;
  }
}
