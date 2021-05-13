using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MachineCartSystem.Configuration
{
    public class CoreService : PreServiceInitializer
    {
        public override void PreInitialize(IServiceCollection services)
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
