using MachineCartSystem.Basket.Api.Initializer;
using MachineCartSystem.Configuration;
using MachineCartSystem.Configuration.Filter;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Linq;

namespace MachineCartSystem.Basket.Api.Initializers
{
    public class SwaggerService : ServiceInitializer
    {
        public override void Initialize(IServiceCollection services, IConfiguration configuration, JwtConfig jwtConfig)
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
        }
    }
}
