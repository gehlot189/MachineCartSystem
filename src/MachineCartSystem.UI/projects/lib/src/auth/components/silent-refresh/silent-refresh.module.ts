import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { RouterModule, Route } from '@angular/router';
import { AuthGuard } from 'projects/lib/src/index/guard.index';
import { SilentRefreshComponent } from './silent-refresh.component';

const routes: Route[] =
  [
    { path: '', component: SilentRefreshComponent, canActivate: [AuthGuard] },
  ];

@NgModule({
  declarations:
    [
      SilentRefreshComponent,
    ],
  imports:
    [
      RouterModule.forChild(routes),
    ],
  schemas: [CUSTOM_ELEMENTS_SCHEMA]
})
export class SilentRefreshModule { }
