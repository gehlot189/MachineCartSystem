using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MachineCartSystem.Configuration
{
    public class GatewaySwaggerMiddleware : PreMiddlewareInitializer
    {
        public override void PreInitialize(IApplicationBuilder app, IConfiguration configuration)
        {
            app.UseSwagger();
            app.UseSwaggerForOcelotUI(p =>
            {
                p.PathToSwaggerGenerator = "/swagger/docs";
                p.ReConfigureUpstreamSwaggerJson = AlterUpstreamSwaggerJson;
                p.EnableFilter();

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

    public class ApiSwaggerMiddleware : PreMiddlewareInitializer
    {
        public override void PreInitialize(IApplicationBuilder app, IConfiguration configuration)
        {
            app.UseSwagger();
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

    public class IdentitySwaggerMiddleware : PreMiddlewareInitializer
    {
        public override void PreInitialize(IApplicationBuilder app, IConfiguration configuration)
        {
            app.UseSwagger();
            app.UseSwaggerUI(p =>
            {
                p.InjectStylesheet("/swagger-ui/custom.css");
                p.SwaggerEndpoint("/swagger/v1/swagger.json", configuration.GetSection("Name").Value);
                p.EnableDeepLinking();
            });
        }
    }
}
