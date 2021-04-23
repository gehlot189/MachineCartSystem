namespace MachineCartSystem.Configuration
{
    public class GlobalConfiguration : IBaseConfiguration
    {
        public string GatewayUrl { get; set; }
        public string IdentityServerUrl { get; set; }
        public string IssuerOrAuthority { get; set; }
        public BaseApiConfiguration Basket { get; set; }
        public BaseApiConfiguration Order { get; set; }
        public BaseApiConfiguration Catalog { get; set; }
    }

    public interface IBaseConfiguration
    {
        public string GatewayUrl { get; set; }
        public string IdentityServerUrl { get; set; }
        public string IssuerOrAuthority { get; set; }
    }

    public class BaseApiConfiguration
    {
        public string Url { get; set; }
        public string Scope { get; set; }
        public string Audiences { get; set; }
        public string PrivateKey { get; set; }
    }
}
