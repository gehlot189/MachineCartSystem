using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;

namespace MachineCartSystem.IdentityServer.Initializer
{
    public class SwaggerMiddleware : MiddlewareInitializer
    {
        public override void Initialize(IApplicationBuilder app, IConfiguration configuration)
        {
            app.UseSwaggerUI(p =>
            {
                p.InjectStylesheet("/swagger-ui/custom.css");
                p.SwaggerEndpoint("/swagger/v1/swagger.json", configuration.GetSection("Name").Value);
                p.EnableDeepLinking();
            });
        }
    }
}
