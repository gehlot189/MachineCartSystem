using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MachineCartSystem.Gateway.Web.Initializer
{
    public class CoreService : ServiceInitializer
    {
        public override void Initialize(IServiceCollection services)
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
