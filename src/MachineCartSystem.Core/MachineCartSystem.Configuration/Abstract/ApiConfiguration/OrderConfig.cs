namespace MachineCartSystem.Configuration
{
    public class BasketConfig : BaseApiConfiguration, IBaseConfiguration
    {
        public string GatewayUrl { get; set; }
        public string IdentityServerUrl { get; set; }
        public string Authority { get; set; }
        public string Issuer { get; set; }
    }
}
