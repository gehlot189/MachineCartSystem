using MachineCartSystem.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Logging;
using System;
using System.Linq;

namespace MachineCartSystem.Gateway.Web.Initializer
{
    public abstract class ServiceInitializer
    {
        public static void Initialize<T>(IServiceCollection services, IConfiguration configuration, JwtConfig jwtConfig) where T : IServiceCollection
        {
            IdentityModelEventSource.ShowPII = true;

            var installers = typeof(ServiceInitializer).Assembly.ExportedTypes.
                             Where(x => typeof(ServiceInitializer).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract).
                             Select(Activator.CreateInstance).Cast<ServiceInitializer>().ToList();

            installers.ForEach(installer =>
            {
                installer.Initialize(services);
                installer.Initialize(services, configuration);
                installer.Initialize(services, jwtConfig);
                installer.Initialize(services, configuration, jwtConfig);
            });
        }
        public virtual void Initialize(IServiceCollection services, IConfiguration configuration, JwtConfig jwtConfig) { }
        public virtual void Initialize(IServiceCollection services, IConfiguration configuration) { }
        public virtual void Initialize(IServiceCollection services, JwtConfig jwtConfig) { }
        public virtual void Initialize(IServiceCollection services) { }
    }
}
