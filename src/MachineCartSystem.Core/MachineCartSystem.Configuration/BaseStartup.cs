using Microsoft.Extensions.Configuration;
using System;
using System.Linq;

namespace MachineCartSystem.Configuration
{
    public abstract class BaseStartup
    {
        protected readonly IConfiguration Configuration;
        protected ApiName _apiName;

        public BaseStartup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public DbConfig DbConfig => GetDbConfigSetting();
        public JwtConfig JwtConfig => JwtConfigSetting();
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
            if (_apiName == ApiName.Gateway)
            {
                var lstApi = Enum.GetNames(typeof(ApiName)).Where(p => p != ApiName.Gateway.ToString()).ToList();

                var scopes = new string[] { Configuration[ApiName.Gateway.ToString() + ":Scopes"] };
                var audiences = new string[] { Configuration[ApiName.Gateway.ToString() + ":Audiences"] };

                lstApi.ForEach(p =>
                {
                    scopes.Append(" " + Configuration[p + ":Scopes"]);
                    audiences.Append(" " + Configuration[p + ":Audiences"]);
                });

                var jwtConfig = new JwtConfig
                {
                    Audiences = audiences,
                    Authority = Configuration["Identity:Authority"],
                    Issuer = Configuration["Identity:Issuer"],
                    //Key = Configuration["PrivateKey"]?.ToCharArray(),
                    Scopes = scopes
                };
                return jwtConfig;
            }

            return new JwtConfig
            {
                Audiences = Configuration["Audiences"]?.Split(new char[] { ',' }),
                Authority = Configuration["Authority"]?.ToString(),
                Issuer = Configuration["Issuer"]?.ToString(),
                //Key = Configuration["PrivateKey"]?.ToCharArray(),
                Scopes = Configuration["Scopes"]?.Split(new char[] { ' ' }),
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