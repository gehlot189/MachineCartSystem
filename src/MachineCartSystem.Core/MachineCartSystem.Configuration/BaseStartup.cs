using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace MachineCartSystem.Configuration
{
    public abstract class BaseStartup
    {
        protected readonly IConfiguration Configuration;

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
            return new JwtConfig
            {
                Audiences = Configuration["Audiences"]?.Split(new char[] { ',' }),
                Authority = Configuration["Authority"]?.ToString(),
                Issuer = Configuration["Issuer"]?.ToString(),
                //Key = Configuration["PrivateKey"]?.ToCharArray(),
                Scopes = Configuration["Scopes"]?.Split(new char[] { ' ' })
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