import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { APP_INITIALIZER, CUSTOM_ELEMENTS_SCHEMA, NgModule } from '@angular/core';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AuthModule, OidcConfigService } from 'angular-auth-oidc-client';
import { ToastrModule } from 'ngx-toastr';
import { AppConfigService, EagerLoadModule, Environment } from 'projects/lib/src/public-api';
import { environment } from '../environments/environment';
import { identityServer } from './../environments/identity-server';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { FooterComponent } from './layout/footer/footer.component';
import { HeaderComponent } from './layout/header/header.component';

export function configureAuth(oidcConfigService: OidcConfigService) {
  return () => {
    return oidcConfigService.withConfig(identityServer);
  };
}

@NgModule({
  declarations:
    [
      AppComponent,
      HeaderComponent,
      FooterComponent,
    ],
  imports:
    [
      CommonModule,
      HttpClientModule,
      BrowserAnimationsModule,
      ToastrModule.forRoot(),
      AuthModule.forRoot(),
      AppRoutingModule,
      EagerLoadModule,
    ],
  providers: [
    { provide: Environment, useValue: environment },
    OidcConfigService,
    {
      provide: APP_INITIALIZER,
      useFactory: configureAuth,
      deps: [OidcConfigService],
      multi: true,
    },
    AppConfigService
  ],
  bootstrap: [AppComponent],
  schemas: [CUSTOM_ELEMENTS_SCHEMA]
})
export class AppModule {
  constructor(private appConfigService: AppConfigService) {
    debugger;
    //  oidcConfigService.withConfig(identityServer);
    appConfigService.loadAppConfig().subscribe(p => {

    }, (err) => {
      debugger;
    });
  }
}
