using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MachineCartSystem.Gateway.Web.Initializer
{
    public class SwaggerMiddleware
    {
        public static void UseSwagger(IApplicationBuilder app, IConfiguration configuration)
        {
            app.UseSwagger();
            app.UseSwaggerForOcelotUI(p =>
            {
                p.PathToSwaggerGenerator = "/swagger/docs";
                p.ReConfigureUpstreamSwaggerJson = AlterUpstreamSwaggerJson;

                p.InjectStylesheet("/swagger-ui/custom.css");
                p.EnableDeepLinking();

                p.OAuthClientId("angular");
                p.OAuthUsePkce();
                p.OAuth2RedirectUrl($"{configuration.GetValue<string>("GatewayUrl")}swagger/oauth2-redirect.html");
            });

             string AlterUpstreamSwaggerJson(HttpContext context, string swaggerJson)
            {
                var swagger = JObject.Parse(swaggerJson);
                // ... alter upstream json
                return swagger.ToString(Formatting.Indented);
            }
        }
    }
}
