import { AlertService } from './../core/services/alert.service';
import { ConfirmDialogComponent } from './components/confirm-dialog/confirm-dialog.component';
import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { BaseComponent } from './components/base/base.component';

@NgModule({
  declarations:
    [
      BaseComponent,
      ConfirmDialogComponent,
    ],
  schemas: [CUSTOM_ELEMENTS_SCHEMA],
})
export class SharedModule { }
