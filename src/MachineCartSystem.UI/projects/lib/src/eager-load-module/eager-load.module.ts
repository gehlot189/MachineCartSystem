import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { ErrorHandler, NgModule } from '@angular/core';
import { TranslateLoader, TranslateModule } from '@ngx-translate/core';
import { PopoverModule } from "ngx-bootstrap/popover";
import { TooltipModule } from "ngx-bootstrap/tooltip";
import { ExceptionHandlerService } from '../exception/exception-handler.service';
import { AuthGuard } from '../index/guard.index';
import { ApiInterceptor, AuthInterceptor, ErrorHandlerInterceptor, LoggingInterceptor } from '../index/interceptor.index';
import { LoggingService } from '../logger/logging.service';
import { AppTranslationService, TranslateLanguageLoader } from '../services/app-translation.service';

@NgModule({
  declarations: [],
  imports: [
    TooltipModule.forRoot(),
    PopoverModule.forRoot(),
    TranslateModule.forRoot({
      loader: {
        provide: TranslateLoader,
        useClass: TranslateLanguageLoader
      }
    }),],
  providers:
    [
      { provide: ErrorHandler, useClass: ExceptionHandlerService },
      { provide: HTTP_INTERCEPTORS, useClass: AuthInterceptor, multi: true },
      { provide: HTTP_INTERCEPTORS, useClass: ApiInterceptor, multi: true },
      { provide: HTTP_INTERCEPTORS, useClass: ErrorHandlerInterceptor, multi: true },
      { provide: HTTP_INTERCEPTORS, useClass: LoggingInterceptor, multi: true },
      AuthGuard,
      AppTranslationService,
      LoggingService
    ]
})
export class EagerLoadModule { }
