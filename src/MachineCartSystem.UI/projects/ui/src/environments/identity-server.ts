import { LogLevel, OpenIdConfiguration } from 'angular-auth-oidc-client';

export const identityServer: OpenIdConfiguration = {
  stsServer: 'http://localhost:5000',
  redirectUrl: `${window.location.origin}/auth-callback`,
  postLogoutRedirectUri: `${window.location.origin}/login`,
  clientId: 'angular',
  scope: 'openid profile order basket',
  responseType: 'code',
  silentRenew: true,
  silentRenewUrl: `${window.location.origin}/silent-refresh`,
  logLevel: LogLevel.Debug,
  // startCheckSession: true,
  // historyCleanupOff: false,
  postLoginRoute: '/',
  forbiddenRoute: '/forbidden',
  unauthorizedRoute: '/unauthorized',
  //maxIdTokenIatOffsetAllowedInSeconds: 40,
  renewTimeBeforeTokenExpiresInSeconds: 10,
  autoUserinfo: true,
  useRefreshToken: false,

  // customParams: {
  //   response_mode: 'fragment',
  //   prompt: 'consent',
  // },
};
