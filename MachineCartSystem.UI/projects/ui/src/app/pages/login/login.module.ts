import { LoginComponent } from './login.component';
import { Routes, RouterModule } from '@angular/router';
import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';

const routes: Routes = [{ path: '', component: LoginComponent, pathMatch: 'full' }];

@NgModule({
  imports:
    [
      RouterModule.forChild(routes)
    ],
  schemas: [CUSTOM_ELEMENTS_SCHEMA]
})
export class LoginModule { }
