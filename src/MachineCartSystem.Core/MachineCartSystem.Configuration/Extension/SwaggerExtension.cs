using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;

namespace MachineCartSystem.Configuration
{
    public static class SwaggerExtension
    {
        public static void UseCustomSwagger(this IApplicationBuilder app, IConfiguration configuration)
        {
            app.UseSwaggerUI(p =>
            {
                p.InjectStylesheet("/swagger-ui/custom.css");
                p.SwaggerEndpoint("/swagger/v1/swagger.json", configuration.GetSection("Name").Value);
                p.EnableDeepLinking();

                if (configuration.GetSection("Name").Value != ApiName.Identity.ToString())
                {
                    p.OAuthClientId("angular");
                    p.OAuthUsePkce();
                    p.OAuth2RedirectUrl($"{configuration.GetSection("Url").Value }swagger/oauth2-redirect.html");
                }
            });
        }
    }
}
