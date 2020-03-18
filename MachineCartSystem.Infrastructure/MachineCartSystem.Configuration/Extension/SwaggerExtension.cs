using MachineCartSystem.Configuration.Filter;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;

namespace MachineCartSystem.Configuration
{
    public static class SwaggerExtension
    {
        public static IServiceCollection AddCustomSwagger(this IServiceCollection services)
        {
            return services.AddSwaggerGen(c =>
             {
                 c.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                 {
                     Type = SecuritySchemeType.OAuth2,
                     Flows = new OpenApiOAuthFlows
                     {
                         AuthorizationCode = new OpenApiOAuthFlow
                         {
                             AuthorizationUrl = new Uri("http://localhost:5000/connect/authorize"),
                             TokenUrl = new Uri("http://localhost:5000/connect/token"),
                             Scopes = new Dictionary<string, string>
                                {
                                    {"openid","openid"},
                                    {"profile","profile"},
                                    {"api1","api1"},
                                }
                         }
                     }
                 });
                 AuthorizeCheckOperationFilter.Scope = new[] { "openid", "profile", "api1" };
                 c.OperationFilter<AuthorizeCheckOperationFilter>();
             });
        }

        public static void UseCustomSwagger(this IApplicationBuilder app, IConfiguration configuration)
        {
            app.UseSwagger();
            app.UseSwaggerUI(p =>
            {
                //  p.RoutePrefix = "";

                p.InjectStylesheet("/swagger-ui/custom.css");
                p.SwaggerEndpoint("/swagger/v1/swagger.json", configuration.GetSection("api:name").Value);
                p.EnableDeepLinking();

                p.OAuthClientId("client");
                p.OAuthUsePkce();
                p.OAuth2RedirectUrl($"{configuration.GetSection("api:host").Value }swagger/oauth2-redirect.html");
            });
        }
    }
}
