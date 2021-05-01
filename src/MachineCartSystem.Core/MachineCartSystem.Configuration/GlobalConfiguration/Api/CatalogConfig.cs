namespace MachineCartSystem.Configuration
{
    public class CatalogConfig : ApiConfiguration, IGlobalConfiguration
    {
        public string GatewayUrl { get; set; }
        public string IdentityServerUrl { get; set; }
        public string Authority { get; set; }
        public string Issuer { get; set; }
        public string AuthenticationProviderKey { get; set; }
    }
}
