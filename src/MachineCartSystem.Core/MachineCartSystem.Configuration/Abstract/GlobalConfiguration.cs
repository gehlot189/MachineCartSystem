using Newtonsoft.Json;

namespace MachineCartSystem.Configuration
{
    public class GlobalConfiguration : IGlobalConfiguration
    {
        public string GatewayUrl { get; set; }
        public string IdentityServerUrl { get; set; }
        public string Issuer { get; set; }
        public string Authority { get; set; }
        public string AuthenticationProviderKey { get; set; }
        public ApiConfiguration Identity { get; set; }
        public ApiConfiguration Basket { get; set; }
        public ApiConfiguration Order { get; set; }
        public ApiConfiguration Catalog { get; set; }
    }

    public interface IGlobalConfiguration
    {
        [JsonProperty("GatewayUrl")]
        public string GatewayUrl { get; set; }
        [JsonProperty("IdentityServerUrl")]
        public string IdentityServerUrl { get; set; }
        [JsonProperty("Authority")]
        public string Authority { get; set; }
        [JsonProperty("Issuer")]
        public string Issuer { get; set; }
        [JsonProperty("AuthenticationProviderKey")]
        public string AuthenticationProviderKey { get; set; }
    }

    public class ApiConfiguration
    {
        [JsonProperty("Url")]
        public string Url { get; set; }
        [JsonProperty("Scopes")]
        public string Scopes { get; set; }
        [JsonProperty("Audiences")]
        public string Audiences { get; set; }
        [JsonProperty("PrivateKey")]
        public string PrivateKey { get; set; }
        [JsonProperty("Name")]
        public string Name { get; set; }
        [JsonProperty("Description")]
        public string Description { get; set; }
    }
}
