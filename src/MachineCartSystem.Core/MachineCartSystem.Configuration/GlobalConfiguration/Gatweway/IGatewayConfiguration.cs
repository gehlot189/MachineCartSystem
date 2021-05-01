using Newtonsoft.Json;

namespace MachineCartSystem.Configuration
{
    public interface IGatewayConfiguration
    {
        [JsonProperty("GatewayUrl")]
        public string GatewayUrl { get; set; }
    }
}
