using MachineCartSystem.Gateway.WebService.Model.OpenIdConfigurationService;
using System.Threading.Tasks;

namespace MachineCartSystem.Gateway.WebService.Service.Configuration
{
    public interface IOpenIdConfigurationService
    {
        Task<OpenIdConfiguration> GetIdentityServerConfiguration();
    }
}
