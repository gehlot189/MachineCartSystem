namespace MachineCartSystem.Configuration
{
    public class BasketConfig : BaseApiConfiguration, IBaseConfiguration
    {
        public string GatewayUrl { get; set; }
        public string IdentityServerUrl { get; set; }
        public string IssuerOrAuthority { get; set; }
    }
}
