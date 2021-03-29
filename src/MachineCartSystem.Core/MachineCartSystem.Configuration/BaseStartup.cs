using MachineCartSystem.Shared;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace MachineCartSystem.Configuration
{
    public abstract class BaseStartup
    {
        protected  IConfiguration Configuration;

        public BaseStartup(IWebHostEnvironment env)
        {
            //Configuration = ConfigReader.GetConfig(env.EnvironmentName);
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
                Audiences = Configuration["jwt:audiences"].Split(new char[] { ',' }),
                Authority = Configuration["jwt:authority"].ToString(),
                Issuer = Configuration["jwt:issuer"].ToString(),
                Key =new Signing { PrivateKey = Configuration["jwt:signing:privateKey"].ToString() },
                Scopes = Configuration["jwt:scopes"].Split(new char[] { ' ' })
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