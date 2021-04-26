namespace MachineCartSystem.Configuration
{
    public class IdentityConfig : BaseApiConfiguration, IBaseConfiguration
    {
        public string GatewayUrl { get; set; }
        public string IdentityServerUrl { get; set; }
        public string Authority { get; set; }
        public string Issuer { get; set; }
    }
}
