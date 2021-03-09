using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MachineCartSystem.Gateway.Web.Initializer
{
    public interface IServiceInitializer
    {
        void Initialize(IServiceCollection services, IConfiguration configuration);
    }
}
