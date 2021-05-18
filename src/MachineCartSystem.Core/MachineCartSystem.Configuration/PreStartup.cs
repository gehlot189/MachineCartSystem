using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace MachineCartSystem.Configuration
{
    public abstract class PreStartup : BaseConfiguration
    {
        private readonly string _apiName = null;
        private readonly IWebHostEnvironment _env;

        protected PreStartup(IConfiguration configuration, IWebHostEnvironment env) : base(configuration)
        {
            _apiName = null;
            _env = env;
        }

        protected PreStartup(IConfiguration configuration, IWebHostEnvironment env, ApiName apiName) : base(configuration)
        {
            _apiName = apiName.ToString();
            _env = env;
        }

        protected DbConfig DbConfig => GetDbConfigSetting();

        protected JwtConfig JwtConfig => JwtConfigSetting();

        protected void Initialize<T>(IServiceCollection services)
        {
            var instance = (IPreServiceInitializer)Activator.CreateInstance(typeof(T));
            instance.Initialize<T>(services, Configuration, JwtConfig);
        }

        protected void Initialize<T>(IApplicationBuilder app)
        {
            var instance = (IPreMiddlewareInitializer)Activator.CreateInstance(typeof(T));
            instance.Initialize<T>(app, _env, Configuration, JwtConfig);
        }
        private DbConfig GetDbConfigSetting()
        {
            var attemptSection = Configuration.GetSection("DbConfiguration:Attempt");
            return new DbConfig
            {
                ConnectionString = Configuration.GetValue<string>("DbConfiguration:ConnectionString"),
                MaxRetryCount = attemptSection.GetValue<int?>("MaxRetryCount"),
                MaxRetryDelayInSeconds = attemptSection.GetValue<int?>("MaxRetryDelayInSeconds")
            };
        }

        private JwtConfig JwtConfigSetting()
        {
            if (_apiName == ApiName.Gateway.ToString())
            {
                var scope_audiences = GetAllScopesAndAudiences();
                var jwtConfig = new JwtConfig
                {
                    Audiences = scope_audiences.Item2,
                    Authority = Configuration["Identity:Authority"],
                    Issuer = Configuration["Identity:Issuer"],
                    //Key = Configuration["PrivateKey"]?.ToCharArray(),
                    Scopes = scope_audiences.Item1,
                    ApiName = ApiName.Gateway
                };
                return jwtConfig;
            }

            return new JwtConfig
            {
                Audiences = Configuration["Audiences"].Split(new char[] { ',' }),
                Authority = Configuration["Authority"]?.ToString(),
                Issuer = Configuration["Issuer"]?.ToString(),
                //Key = Configuration["PrivateKey"]?.ToCharArray(),
                Scopes = Configuration["Scopes"]?.Split(new char[] { ',' }),
                ApiName = (ApiName)Enum.Parse(typeof(ApiName), Configuration["Name"]?.ToString()),
            };
        }

        //public Assembly[] profiles
        //{
        //    get
        //    {
        //        var assemly = AppDomain.CurrentDomain.GetAssemblies();
        //        return assemly;
        //    }
        //}
    }
}