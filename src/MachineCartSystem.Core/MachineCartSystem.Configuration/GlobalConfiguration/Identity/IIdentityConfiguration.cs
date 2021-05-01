using Newtonsoft.Json;

namespace MachineCartSystem.Configuration
{
    public interface IIdentityConfiguration : IIdentityBaseConfiguration
    {
        [JsonProperty("IdentityServerUrl")]
        public string IdentityServerUrl { get; set; }
    }

    public interface IIdentityBaseConfiguration
    {
        [JsonProperty("Authority")]
        public string Authority { get; set; }
        [JsonProperty("Issuer")]
        public string Issuer { get; set; }
    }

    public class IdentityApiConfiguration : ApiConfiguration, IIdentityBaseConfiguration
    {
        [JsonProperty("Authority")]
        public string Authority { get; set; }
        [JsonProperty("Issuer")]
        public string Issuer { get; set; }
    }
}
