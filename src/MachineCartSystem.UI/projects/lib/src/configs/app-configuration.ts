import { AuthWellKnownEndpoints, OpenIdConfiguration } from "angular-auth-oidc-client";

export interface AppConfiguration {
  authWellKnownEndpoints: AuthWellKnownEndpoints;
  openIdConfiguration: OpenIdConfiguration;
  isAuthWellKnownEndpointsRequired: boolean;
}
