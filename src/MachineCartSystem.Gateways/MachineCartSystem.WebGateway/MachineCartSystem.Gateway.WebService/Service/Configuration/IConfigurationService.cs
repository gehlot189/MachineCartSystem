using MachineCartSystem.Configuration;
using System.Threading.Tasks;

namespace MachineCartSystem.Gateway.WebService.Service
{
    public interface IConfigurationService
    {
        Task<object> GetApiConfiguration(ApiName apiName );
        Task<OpenIdConfiguration> GetOpenIdConfigurationConfiguration();
    }
}
