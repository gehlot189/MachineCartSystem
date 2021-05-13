using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Text.Json;

namespace MachineCartSystem.Configuration
{
    public class ContollerService : PreServiceInitializer
    {
        public override void PreInitialize(IServiceCollection services)
        {
            services.AddControllers(p =>
            {

            }).AddJsonOptions(p =>
            {
                p.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
            });
        }
    }
}
