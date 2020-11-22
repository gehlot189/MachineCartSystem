import { AlertService } from './../core/services/alert.service';
import { ExceptionHandlerService } from './../core/exception/exception-handler.service';
import { NgModule, ErrorHandler } from '@angular/core';
import { AuthGuard } from '../index/guard.index';
import { AppTranslationService, TranslateLanguageLoader } from '../core/services/app-translation.service';
import { TranslateLoader, TranslateModule } from '@ngx-translate/core';
import { TooltipModule } from "ngx-bootstrap/tooltip";
import { PopoverModule } from "ngx-bootstrap/popover";

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
      { useClass: ExceptionHandlerService, provide: ErrorHandler },
      AuthGuard,
      AlertService,
      AppTranslationService,
    ]
})
export class EagerLoadModule { }
