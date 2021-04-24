using Newtonsoft.Json;

namespace MachineCartSystem.Configuration
{
    public class GlobalConfiguration : IBaseConfiguration
    {
        public string GatewayUrl { get; set; }
        public string IdentityServerUrl { get; set; }
        public string Issuer { get; set; }
        public string Authority { get; set; }
        public BaseApiConfiguration Basket { get; set; }
        public BaseApiConfiguration Order { get; set; }
        public BaseApiConfiguration Catalog { get; set; }
    }

    public interface IBaseConfiguration
    {
        [JsonProperty("GatewayUrl")]
        public string GatewayUrl { get; set; }
        [JsonProperty("IdentityServerUrl")]
        public string IdentityServerUrl { get; set; }
        [JsonProperty("Authority")]
        public string Authority { get; set; }
        [JsonProperty("Issuer")]
        public string Issuer { get; set; }
    }

    public class BaseApiConfiguration
    {
        [JsonProperty("Url")]
        public string Url { get; set; }
        [JsonProperty("Scopes")]
        public string Scopes { get; set; }
        [JsonProperty("Audiences")]
        public string Audiences { get; set; }
        [JsonProperty("PrivateKey")]
        public string PrivateKey { get; set; }
    }
}
