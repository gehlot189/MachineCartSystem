using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Text.Json;

namespace MachineCartSystem.Gateway.Web.Initializer
{
    public class ContollerService : IServiceInitializer
    {
        public void Initialize(IServiceCollection services, IConfiguration configuration)
        {
             services.AddControllers(p=>
             {

             }).AddNewtonsoftJson().AddJsonOptions(p=>
             {
                 p.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
             });
        }   
    }
}
