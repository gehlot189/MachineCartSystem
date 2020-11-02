using MachineCartSystem.Configuration.Filter;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Linq;

namespace MachineCartSystem.Gateway.WebService.Initializers
{
    public class SwaggerUIService
    {
        public static void Initialize(IServiceCollection services, IConfiguration configuration, JwtConfig jwtConfig)
        {
            services.AddSwaggerForOcelot(configuration);

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
                            Scopes = jwtConfig.Scopes.ToDictionary(p => p)
                        }
                    }
                });
                AuthorizeCheckOperationFilter.Scope = jwtConfig.Scopes.ToList();
                c.OperationFilter<AuthorizeCheckOperationFilter>();
            });
        }
    }
}
