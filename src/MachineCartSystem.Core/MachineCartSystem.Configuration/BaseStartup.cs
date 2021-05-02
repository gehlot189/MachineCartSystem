using Microsoft.Extensions.Configuration;
using System.Linq;

namespace MachineCartSystem.Configuration
{
    public abstract class BaseStartup : BaseConfiguration
    {
        private readonly string _apiName = null;

        public BaseStartup(IConfiguration configuration) : base(configuration)
        {
            _apiName = null;
        }

        public BaseStartup(IConfiguration configuration, ApiName apiName) : base(configuration)
        {
            _apiName = apiName.ToString();
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
            if (_apiName == ApiName.Gateway.ToString())
            {
                var scope_audiences = GetAllScopesAndAudiences();
                var jwtConfig = new JwtConfig
                {
                    Audiences = scope_audiences.Item2,
                    Authority = Configuration["Identity:Authority"],
                    Issuer = Configuration["Identity:Issuer"],
                    //Key = Configuration["PrivateKey"]?.ToCharArray(),
                    Scopes = scope_audiences.Item1
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