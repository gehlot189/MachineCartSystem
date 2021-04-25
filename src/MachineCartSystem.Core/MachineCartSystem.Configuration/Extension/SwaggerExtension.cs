using MachineCartSystem.Configuration.Filter;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MachineCartSystem.Configuration
{
    public static class SwaggerExtension
    {
        public static IServiceCollection AddCustomSwagger(this IServiceCollection services,
            IConfiguration configuration, JwtConfig jwtConfig)
        {
            services.AddSwaggerGen(c =>
            {
                c.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.OAuth2,
                    Flows = new OpenApiOAuthFlows
                    {
                        AuthorizationCode = new OpenApiOAuthFlow
                        {
                            AuthorizationUrl = new Uri($"{configuration.GetValue<string>("IdentityServerUrl")}connect/authorize"),
                            TokenUrl = new Uri($"{configuration.GetValue<string>("IdentityServerUrl")}connect/token"),
                            Scopes = jwtConfig.Scopes.ToDictionary(p => p),
                        }
                    },
                });
                AuthorizeCheckOperationFilter.Scope = jwtConfig.Scopes.ToList();
                c.OperationFilter<AuthorizeCheckOperationFilter>();
            });
            return services;
        }

        public static void UseCustomSwagger(this IApplicationBuilder app, IConfiguration configuration)
        {
            app.UseSwagger();
            app.UseSwaggerUI(p =>
            {
                p.InjectStylesheet("/swagger-ui/custom.css");
                p.SwaggerEndpoint("/swagger/v1/swagger.json", configuration.GetSection("api:name").Value);
                p.EnableDeepLinking();

                p.OAuthClientId("angular");
                p.OAuthUsePkce();
                p.OAuth2RedirectUrl($"{configuration.GetSection("api:host").Value }swagger/oauth2-redirect.html");
            });
        }
    }
}
