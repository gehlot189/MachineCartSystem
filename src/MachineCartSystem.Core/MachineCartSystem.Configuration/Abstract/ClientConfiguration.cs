namespace MachineCartSystem.Configuration
{
    public class ClientConfiguration  
    {
        public AuthWellKnownEndpoints AuthWellKnownEndpoints { get; set; }
        public OpenIdConfiguration OpenIdConfiguration { get; set; }
        public bool IsAuthWellKnownEndpointsRequired { get; set; }
    }

    public class OpenIdConfiguration
    {
        public string StsServer { get; set; }
        public string RedirectUrl { get; set; }
        public string PostLogoutRedirectUri { get; set; }
        public string ClientId { get; set; }
        public string Scope { get; set; }
        public string ResponseType { get; set; }
        public bool? SilentRenew { get; set; }
        public string SilentRenewUrl { get; set; }
        public LogLevel LogLevel { get; set; }
        public string PostLoginRoute { get; set; }
        public string ForbiddenRoute { get; set; }
        public string UnauthorizedRoute { get; set; }
        public int? RenewTimeBeforeTokenExpiresInSeconds { get; set; }
        public bool? AutoUserinfo { get; set; }
        public bool? UseRefreshToken { get; set; }
        public bool? TriggerAuthorizationResultEvent { get; set; }
        public bool? IgnoreNonceAfterRefresh { get; set; }
        //public CustomParams CustomParams { get; set; }
        //public CustomTokenParams CustomTokenParams { get; set; }
        public int? SilentRenewTimeoutInSeconds { get; set; }
        public bool? UsePushedAuthorisationRequests { get; set; }
        public bool? RenewUserInfoAfterTokenRenew { get; set; }
        public bool? AutoCleanStateAfterAuthentication { get; set; }
        public bool? IssValidationOff { get; set; }
        public bool? DisableIatOffsetValidation { get; set; }
        //public object Storage { get; set; }
        public bool? EagerLoadAuthWellKnownEndpoints { get; set; }
        public bool? DisableRefreshIdTokenAuthTimeValidation { get; set; }
        public int? TokenRefreshInSeconds { get; set; }
        public string[] SecureRoutes { get; set; }
        public int? RefreshTokenRetryInSeconds { get; set; }
        public bool? NgswBypass { get; set; }
        public string AuthWellknownEndpoint { get; set; }
    }

    public class CustomParams
    {
        public object Prompt { get; set; }
    }
    public class CustomTokenParams
    {
        public object Prompt { get; set; }
    }

    public class AuthWellKnownEndpoints
    {
        public string Issuer { get; set; }
        public string JwksUri { get; set; }
        public string AuthorizationEndpoint { get; set; }
        public string TokenEndpoint { get; set; }
        public string UserinfoEndpoint { get; set; }
        public string EndSessionEndpoint { get; set; }
        public string CheckSessionIframe { get; set; }
        public string RevocationEndpoint { get; set; }
        public string IntrospectionEndpoint { get; set; }
        public string DeviceAuthorizationEndpoint { get; set; }
    }
}
