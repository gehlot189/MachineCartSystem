namespace MachineCartSystem.Gateway
{
    public class GlobalConfiguration 
    {
        public string GatewayUrl { get; set; }
        public string IdentityServerUrl { get; set; }
        public string IssuerOrAuthority { get; set; }
        public BaseApi Basket { get; set; }
        public BaseApi Order { get; set; }
        public BaseApi Catalog { get; set; }
    }

    public class BaseApi
    {
        public string Url { get; set; }
        public string Scope { get; set; }
        public string Audiences { get; set; }
        public string PrivateKey { get; set; }
    }

}
