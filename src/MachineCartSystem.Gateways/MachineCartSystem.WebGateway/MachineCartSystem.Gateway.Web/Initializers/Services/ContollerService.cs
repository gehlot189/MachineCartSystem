using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Text.Json;

namespace MachineCartSystem.Gateway.Web.Initializer
{
    public class ContollerService : ServiceInitializer
    {
        public override void Initialize(IServiceCollection services)
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
