using MachineCartSystem.Configuration.Filter;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;

namespace MachineCartSystem.Gateway.WebService.Initializers
{
    public class SwaggerUIService : IServiceInitializer
    {
        public void Initialize(IServiceCollection services, IConfiguration configuration)
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
    }
}
