using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Logging;
using System;
using System.Linq;

namespace MachineCartSystem.Configuration
{
    public interface IPreServiceInitializer
    {
        public void Initialize<T>(IServiceCollection services, IConfiguration configuration, JwtConfig jwtConfig);
    }

    public abstract class PreServiceInitializer : IPreServiceInitializer
    {
        public void Initialize<T>(IServiceCollection services, IConfiguration configuration, JwtConfig jwtConfig)
        {
            if (!Attribute.IsDefined(typeof(T), typeof(ExecutionSequence)))
                throw new Exception($"ExecutionSequence attribute is missing in class {typeof(T).FullName}");

            var executionSequence = typeof(T).GetCustomAttributes(typeof(ExecutionSequence), false).Cast<ExecutionSequence>().FirstOrDefault().Sequence;

            IdentityModelEventSource.ShowPII = true;

            var serviceInstallers = typeof(T).Assembly.ExportedTypes.
                                 Where(x => typeof(T).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract && x.Name != typeof(T).Name).
                                 Select(Activator.CreateInstance).Cast<T>().ToList();

            var preInstallers = typeof(PreServiceInitializer).Assembly.ExportedTypes.
                               Where(x => typeof(PreServiceInitializer).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract).
                               Select(Activator.CreateInstance).Cast<PreServiceInitializer>().ToList();

            executionSequence.ForEach(installer =>
            {
                var serviceInstaller = serviceInstallers.FirstOrDefault(p => p.GetType().Name == installer);
                var preInstaller = preInstallers.FirstOrDefault(p => p.GetType().Name == installer);

                if (preInstaller != null)
                {
                    preInstaller.PreInitialize(services);
                    preInstaller.PreInitialize(services, configuration);
                    preInstaller.PreInitialize(services, jwtConfig);
                    preInstaller.PreInitialize(services, configuration, jwtConfig);
                }
                if (serviceInstaller != null)
                {
                    var serviceInstaller1 = (PreServiceInitializer)Activator.CreateInstance(serviceInstaller.GetType());
                    serviceInstaller1.Initialize(services);
                    serviceInstaller1.Initialize(services, configuration);
                    serviceInstaller1.Initialize(services, jwtConfig);
                    serviceInstaller1.Initialize(services, configuration, jwtConfig);
                }
            });
        }

        public virtual void PreInitialize(IServiceCollection services, IConfiguration configuration, JwtConfig jwtConfig) { }

        public virtual void PreInitialize(IServiceCollection services, IConfiguration configuration) { }

        public virtual void PreInitialize(IServiceCollection services, JwtConfig jwtConfig) { }

        public virtual void PreInitialize(IServiceCollection services) { }

        public virtual void Initialize(IServiceCollection services, IConfiguration configuration, JwtConfig jwtConfig) { }

        public virtual void Initialize(IServiceCollection services, IConfiguration configuration) { }

        public virtual void Initialize(IServiceCollection services, JwtConfig jwtConfig) { }

        public virtual void Initialize(IServiceCollection services) { }
    }
}
