﻿using MachineCartSystem.Configuration.Filter;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Linq;

namespace MachineCartSystem.Configuration
{
    public class GatewaySwaggerService : PreServiceInitializer
    {
        public override void PreInitialize(IServiceCollection services, IConfiguration configuration, JwtConfig jwtConfig)
        {
                services.AddSwaggerForOcelot(configuration, o =>
                {
                    o.GenerateDocsForAggregates = true;
                    // o.GenerateDocsForGatewayItSelf = true;

                    o.AggregateDocsGeneratorPostProcess = (aggregateRoute, routesDocs, pathItemDoc, documentation) =>
                        {
                            if (aggregateRoute.UpstreamPathTemplate == "/gateway/api/basketwithuser/{id}")
                            {
                                pathItemDoc.Operations[OperationType.Get].Parameters.Add(new OpenApiParameter()
                                {
                                    Name = "customParameter",
                                    Schema = new OpenApiSchema() { Type = "string" },
                                    In = ParameterLocation.Header
                                });
                            }
                        };
                });
        }
    }

    public class ApiSwaggerService : PreServiceInitializer
    {
        public override void PreInitialize(IServiceCollection services, IConfiguration configuration, JwtConfig jwtConfig)
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

    public class IdentitySwaggerService : PreServiceInitializer
    {
        public override void PreInitialize(IServiceCollection services, IConfiguration configuration, JwtConfig jwtConfig)
        {
            services.AddSwaggerGen();
        }
    }
}
