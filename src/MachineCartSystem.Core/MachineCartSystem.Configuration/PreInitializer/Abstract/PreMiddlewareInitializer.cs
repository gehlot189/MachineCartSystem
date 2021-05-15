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
            if (!Attribute.IsDefined(typeof(T), typeof(ExecutionSequence)))
                throw new System.Exception($"ExecutionSequence attribute is missing in class {typeof(T).FullName}");

            var executionSequence = typeof(T).GetCustomAttributes(typeof(ExecutionSequence), false).Cast<ExecutionSequence>().FirstOrDefault().Sequence;

            var serviceInstallers = typeof(T).Assembly.ExportedTypes.
                                 Where(x => typeof(T).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract && x.Name != typeof(T).Name).
                                 Select(Activator.CreateInstance).Cast<T>().ToList();

            var preInstallers = typeof(PreMiddlewareInitializer).Assembly.ExportedTypes.
                               Where(x => typeof(PreMiddlewareInitializer).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract).
                               Select(Activator.CreateInstance).Cast<PreMiddlewareInitializer>().ToList();

            var installers = serviceInstallers.FullOuterJoin(p => p.GetType().Name, preInstallers, p => p.GetType().Name)
                                .OrderByDescending(p => p.Value).ToList();

            executionSequence.ForEach(installer =>
             {
                 var serviceInstaller = serviceInstallers.FirstOrDefault(p => p.GetType().Name == installer);
                 var preInstaller = preInstallers.FirstOrDefault(p => p.GetType().Name == installer);

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

        //protected void AddSequence(params Type[] types)
        //{
        //    types.ToList().ForEach(p =>
        //    {
        //        if (p.IsSubclassOf(typeof(PreMiddlewareInitializer)))
        //        {
        //            _executionSequence.Add(p.Name);
        //            return;
        //        }
        //        throw new System.Exception("Invalid type. Type must be PreMiddlewareInitializer");
        //    });
        //}
    }
}
