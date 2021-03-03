using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MachineCartSystem.Gateway.WebService.Initializers.Services
{
    public class CoreService : IServiceInitializer
    {
        public void Initialize(IServiceCollection services, IConfiguration configuration)
        {
            services.AddCors(p =>
               {
                   p.AddPolicy("CorsPolicy", q =>
                   {
                      q.SetIsOriginAllowed((host) => true)
                    // q.AllowAnyOrigin()
                      .AllowAnyMethod()
                      .AllowAnyHeader()
                      .AllowCredentials();
                   });
               });
        }
    }
}
