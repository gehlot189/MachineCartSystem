using MachineCartSystem.Configuration;
using MachineCartSystem.Gateway.WebService.Initializers.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace MachineCartSystem.Gateway.WebService.Initializers
{
    public static class ServiceInitializer
    {
        public static void InitializeAllServices(this IServiceCollection services, IConfiguration configuration, JwtConfig jwtConfig)
        {
            InitializeService(services, configuration);
            // AutoMapperService.Initialize(exportedTypes, services);
            //  DbService.Initialize(exportedTypes, services, configuration);
            // HealthCheckService.Initialize<new DbContext()>(services);

            AuthenticationService.Initialize(services, jwtConfig);
            SwaggerUIService.Initialize(services, configuration, jwtConfig);
            services.AddAuthorization();

            //  .AddConsul()
            // .AddConfigStoredInConsul();
            //.AddDevspaces()

            //services.AddHttpClient("", p =>
            // {
            //     p.BaseAddress = new System.Uri("");
            // }).AddHttpMessageHandler<HttpClientAuthorizationDelegatingHandler>()
            //    .AddDevspacesSupport();
        }

        private static void InitializeService(IServiceCollection services, IConfiguration configuration)
        {
            var installers = typeof(ServiceInitializer).Assembly.ExportedTypes.
                             Where(x => typeof(IServiceInitializer).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract).
                             Select(Activator.CreateInstance).Cast<IServiceInitializer>().ToList();

            installers.ForEach(installer =>
            {
                installer.Initialize(services, configuration);
            });
        }
    }
}
