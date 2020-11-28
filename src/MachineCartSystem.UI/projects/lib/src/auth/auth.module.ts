import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { RouterModule, Route } from '@angular/router';

const routes: Route[] =
  [
  ];

@NgModule({
  declarations:
    [
    ],
  imports:
    [
      RouterModule.forChild(routes),
    ],
  schemas: [CUSTOM_ELEMENTS_SCHEMA]
})
export class AuthModule { }
