using MachineCartSystem.Configuration;

namespace MachineCartSystem.Gateway.WebService
{
    public class OpenIdConfiguration
    {
        public string StsServer { get; set; }
        public string RedirectUrl { get; set; }
        public string PostLogoutRedirectUri { get; set; }
        public string ClientId { get; set; }
        public string Scope { get; set; }
        public string ResponseType { get; set; }
        public bool SilentRenew { get; set; }
        public string SilentRenewUrl { get; set; }
        public string LilentRenewUrl { get; set; }
        public LogLevel LogLevel { get; set; }
        public string PostLoginRoute { get; set; }
        public string ForbiddenRoute { get; set; }
        public string UnauthorizedRoute { get; set; }
        public int RenewTimeBeforeTokenExpiresInSeconds { get; set; }
        public bool AutoUserinfo { get; set; }
        public bool UseRefreshToken { get; set; }
    }
}
