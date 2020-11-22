import { FooterComponent } from './layout/footer/footer.component';
import { HeaderComponent } from './layout/header/header.component';
import { identityServer } from './../environments/identity-server';
import { NgModule, CUSTOM_ELEMENTS_SCHEMA, APP_INITIALIZER } from '@angular/core';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToastrModule } from 'ngx-toastr';
import { AuthModule, OidcConfigService } from 'angular-auth-oidc-client';
import { HttpClientModule } from '@angular/common/http';
import { EagerLoadModule } from 'projects/lib/src/public-api';

export function configureAuth(oidcConfigService: OidcConfigService) {
  return () => oidcConfigService.withConfig(identityServer);
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
      HttpClientModule,
      BrowserAnimationsModule,
      ToastrModule.forRoot(),
      AuthModule.forRoot(),
      AppRoutingModule,
      EagerLoadModule,
    ],
  providers: [
    OidcConfigService,
    {
      provide: APP_INITIALIZER,
      useFactory: configureAuth,
      deps: [OidcConfigService],
      multi: true,
    }
  ],
  bootstrap: [AppComponent],
  schemas: [CUSTOM_ELEMENTS_SCHEMA]
})
export class AppModule {
}
