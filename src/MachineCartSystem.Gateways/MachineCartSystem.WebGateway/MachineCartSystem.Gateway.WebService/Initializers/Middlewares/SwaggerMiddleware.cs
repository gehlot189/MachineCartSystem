using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;

namespace MachineCartSystem.Gateway.WebService.Initializers
{
    public class SwaggerMiddleware
    {
        public static void UseSwagger(IApplicationBuilder app, IConfiguration configuration)
        {
            app.UseSwagger();
            app.UseSwaggerForOcelotUI(p =>
            {
                p.InjectStylesheet("/swagger-ui/custom.css");
                p.EnableDeepLinking();

                p.OAuthClientId("angular");
                p.OAuthUsePkce();
                p.OAuth2RedirectUrl($"{configuration.GetValue<string>("GatewayUrl")}swagger/oauth2-redirect.html");
            });
        }
    }
}
