import { CommonModule } from '@angular/common';
import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AuthGuard } from 'projects/lib/src/public-api';
import { AppPreloadingStrategy } from './app-preloading-strategy';
import { DashboardComponent, NoPageComponent } from './pages/pages-index';

const routes: Routes =
  [
    { path: '', component: DashboardComponent, canActivate: [AuthGuard], data: { title: 'Dash' } },
    { path: 'auth-callback', loadChildren: () => import('../../../lib/src/auth/components/auth-callback/auth-callback.module').then(p => p.AuthCallBackModule) },
    { path: 'silent-refresh', loadChildren: () => import('../../../lib/src/auth/components/silent-refresh/silent-refresh.module').then(p => p.SilentRefreshModule) },
    { path: 'login', loadChildren: () => import('./pages/login/login.module').then(p => p.LoginModule) },
    //{ path: '**', component: NoPageComponent },
  ];

@NgModule({
  declarations: [DashboardComponent],
  imports:
    [
      CommonModule,
      RouterModule.forRoot(routes, { preloadingStrategy: AppPreloadingStrategy })
    ],
  providers: [AppPreloadingStrategy],
  exports: [RouterModule],
  //provideRoutes([])
  schemas: [CUSTOM_ELEMENTS_SCHEMA]
})
export class AppRoutingModule { }


