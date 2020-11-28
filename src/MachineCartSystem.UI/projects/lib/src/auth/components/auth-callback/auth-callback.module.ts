import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { RouterModule, Route } from '@angular/router';
import { AuthCallbackComponent } from '../auth-callback/auth-callback.component';

const routes: Route[] = [{ path: '', component: AuthCallbackComponent }];

@NgModule({
  declarations: [AuthCallbackComponent],
  imports: [RouterModule.forChild(routes),],
  schemas: [CUSTOM_ELEMENTS_SCHEMA]
})
export class AuthCallBackModule { }
