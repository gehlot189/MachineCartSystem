using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;

namespace MachineCartSystem.Catalog.Api.Initializer
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

                p.OAuthClientId("angular");
                p.OAuthUsePkce();
                p.OAuth2RedirectUrl($"{configuration.GetSection("Url").Value }swagger/oauth2-redirect.html");
            });
        }
    }
}
