import { AuthGuard } from './../guards/auth.guard';
import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { RouterModule, Route } from '@angular/router';
import { SilentRefreshComponent } from './components/silent-refresh/silent-refresh.component';

const routes: Route[] =
  [
    { path: 'silent-refresh', component: SilentRefreshComponent, canActivate: [AuthGuard] },
  ];

@NgModule({
  declarations: [SilentRefreshComponent],
  imports:
    [
      RouterModule.forChild(routes),
    ],
  schemas: [CUSTOM_ELEMENTS_SCHEMA]
})
export class AuthRoutingModule {
}
