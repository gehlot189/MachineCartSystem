using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;

namespace MachineCartSystem.Configuration
{
    public interface IPreMiddlewareInitializer
    {
        public void Initialize<T>(IApplicationBuilder app, IWebHostEnvironment env, IConfiguration configuration);
    }

    public abstract class PreMiddlewareInitializer : IPreMiddlewareInitializer
    {
        public void Initialize<T>(IApplicationBuilder app, IWebHostEnvironment env, IConfiguration configuration)
        {
            var serviceInstallers = typeof(T).Assembly.ExportedTypes.
                                 Where(x => typeof(T).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract && x.Name != typeof(T).Name).
                                 Select(Activator.CreateInstance).Cast<T>().ToList();

            var preInstallers = typeof(PreMiddlewareInitializer).Assembly.ExportedTypes.
                               Where(x => typeof(PreMiddlewareInitializer).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract).
                               Select(Activator.CreateInstance).Cast<PreMiddlewareInitializer>().ToList();

            var installers = serviceInstallers.FullOuterJoin(p => p.GetType().Name, preInstallers, p => p.GetType().Name)
                                .OrderByDescending(p=>p.Value).ToList();

            installers.ForEach(installer =>
            {
                var serviceInstaller = serviceInstallers.FirstOrDefault(p => p.GetType().Name == installer.Key?.GetType().Name);
                var preInstaller = preInstallers.FirstOrDefault(p => p.GetType().Name == installer.Value?.GetType().Name);

                if (preInstaller != null)
                {
                    preInstaller.PreInitialize(app, env, configuration);
                }
                if (serviceInstaller != null)
                {
                    var serviceInstaller1 = (PreMiddlewareInitializer)Activator.CreateInstance(serviceInstaller.GetType());
                    serviceInstaller1.Initialize(app);
                    serviceInstaller1.Initialize(app, configuration);
                    serviceInstaller1.Initialize(app, env, configuration);
                }
            });
        }

        public virtual void PreInitialize(IApplicationBuilder app, IWebHostEnvironment env, IConfiguration configuration) { }

        public virtual void Initialize(IApplicationBuilder app) { }

        public virtual void Initialize(IApplicationBuilder app, IConfiguration configuration) { }

        public virtual void Initialize(IApplicationBuilder app, IWebHostEnvironment env, IConfiguration configuration) { }
    }
}
