import { Injectable } from '@angular/core';

@Injectable()
export class LoggingService {

  constructor() { }

  logError(msg) {
    console.log(msg);
  }

  logInfo(msg) {
    console.log(msg);

  }
}
