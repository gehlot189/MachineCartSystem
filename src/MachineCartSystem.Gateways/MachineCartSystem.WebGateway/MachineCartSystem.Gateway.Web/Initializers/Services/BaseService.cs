using MachineCartSystem.Gateway.WebService.Service;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MachineCartSystem.Gateway.Web.Initializer
{
    public class BaseService : ServiceInitializer
    {
        public override void Initialize(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IConfigurationService, ConfigurationService>();
        }
    }
}
