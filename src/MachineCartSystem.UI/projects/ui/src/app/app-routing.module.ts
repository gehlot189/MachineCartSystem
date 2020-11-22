import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { Routes, RouterModule, PreloadAllModules } from '@angular/router';
import { AuthGuard } from 'projects/lib/src/public-api';
import { DashboardComponent, NoPageComponent } from './pages/pages-index';

const routes: Routes =
  [
    { path: '', component: DashboardComponent },
    { path: 'login', loadChildren: () => import('./pages/login/login.module').then(p => p.LoginModule) },
    { path: 'lib', loadChildren: () => import('../../../lib/src/public-api').then(p => p.AuthModule) },
    { path: '**', component: NoPageComponent },
  ];

@NgModule({
  declarations: [DashboardComponent],
  imports:
    [
      RouterModule.forRoot(routes, { preloadingStrategy: PreloadAllModules }),
    ],
  providers: [],
  exports: [RouterModule],
  //provideRoutes([])
  schemas: [CUSTOM_ELEMENTS_SCHEMA]
})
export class AppRoutingModule { }
