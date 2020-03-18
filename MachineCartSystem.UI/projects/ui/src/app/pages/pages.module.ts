import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { PagesRoutingModule } from './pages-routing.module';

@NgModule({
  imports:
    [
      PagesRoutingModule
    ],
  schemas: [CUSTOM_ELEMENTS_SCHEMA]
})
export class PagesModule { }
