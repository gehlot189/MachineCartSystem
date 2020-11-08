using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MachineCartSystem.Gateway.WebService.Initializers
{
    public class ContollerService : IServiceInitializer
    {
        public void Initialize(IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllers().AddNewtonsoftJson();
        }
    }
}
