import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { PagesRoutingModule } from './pages-routing.module';
import { CustomerComponent } from './customer/customer.component';

@NgModule({
  imports:
    [
      PagesRoutingModule
    ],
  schemas: [CUSTOM_ELEMENTS_SCHEMA],
  declarations: [CustomerComponent]
})
export class PagesModule { }
