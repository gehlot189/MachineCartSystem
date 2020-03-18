import { Injectable, ErrorHandler, Injector } from '@angular/core';
import { LoggingService } from '../logger/logging.service';

@Injectable()
export class ExceptionHandlerService implements ErrorHandler {

  constructor(private injector: Injector) {

  }

  handleError(error) {
    const loggingService = this.injector.get(LoggingService);
    // throw error;
  }

}
