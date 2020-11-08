import { NgModule, SkipSelf, Optional, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { AuthRoutingModule } from './auth-routing.module';

@NgModule({
  declarations: [],
  imports:
    [
      AuthRoutingModule,
    ],
  providers: [],
  schemas: [CUSTOM_ELEMENTS_SCHEMA]
})
export class AuthModule {
  constructor(@Optional() @SkipSelf() parentModule: AuthModule) {
    if (parentModule) {
      throw new Error(
        'AuthModule is already loaded. Import it in the AppModule only');
    }
  }
}
