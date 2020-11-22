import { LoginComponent } from './login.component';
import { Routes, RouterModule } from '@angular/router';
import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

const routes: Routes = [{ path: '', component: LoginComponent, pathMatch: 'full' }];

@NgModule({
  declarations: [LoginComponent],
  imports:
    [
      CommonModule,
      FormsModule,
      RouterModule.forChild(routes)
    ],
  schemas: [CUSTOM_ELEMENTS_SCHEMA]
})
export class LoginModule { }
