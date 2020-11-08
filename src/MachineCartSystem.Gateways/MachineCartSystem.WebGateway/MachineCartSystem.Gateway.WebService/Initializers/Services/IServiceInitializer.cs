using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MachineCartSystem.Gateway.WebService.Initializers
{
    public interface IServiceInitializer
    {
        void Initialize(IServiceCollection services, IConfiguration configuration);
    }
}
