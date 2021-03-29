import { AlertService } from './../services/alert.service';
import { ExceptionHandlerService } from './../exception/exception-handler.service';
import { NgModule, ErrorHandler } from '@angular/core';
import { AuthGuard } from '../index/guard.index';
import { AppTranslationService, TranslateLanguageLoader } from '../services/app-translation.service';
import { TranslateLoader, TranslateModule } from '@ngx-translate/core';
import { TooltipModule } from "ngx-bootstrap/tooltip";
import { PopoverModule } from "ngx-bootstrap/popover";
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { ApiPrefixInterceptor, HttpTokenInterceptor, ErrorHandlerInterceptor } from '../index/interceptor.index';

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
      { provide: HTTP_INTERCEPTORS, useClass: HttpTokenInterceptor, multi: true },
      { provide: HTTP_INTERCEPTORS, useClass: ErrorHandlerInterceptor, multi: true },
      { provide: HTTP_INTERCEPTORS, useClass: ApiPrefixInterceptor, multi: true },
      AuthGuard,
      AlertService,
      AppTranslationService,
    ]
})
export class EagerLoadModule { }
