using MachineCartSystem.Configuration.Config.FileConfigProvider;
using System.Threading.Tasks;

namespace MachineCartSystem.Gateway.WebService.Service
{
    public interface IConfigurationService
    {
        Task<object> GetApiConfiguration(ApiEnv apiEnv);
        Task<object> GetOpenIdConfigurationConfiguration();
    }
}
