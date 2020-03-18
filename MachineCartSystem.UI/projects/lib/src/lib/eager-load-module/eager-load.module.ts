import { ExceptionHandlerService } from './../core/exception/exception-handler.service';
import { NgModule, ErrorHandler } from '@angular/core';
import { AuthGuard } from '../index/guard.index';

@NgModule({
  declarations: [],
  imports: [],
  providers:
    [
      { useClass: ExceptionHandlerService, provide: ErrorHandler },
      AuthGuard
    ]
})
export class EagerLoadModule { }
