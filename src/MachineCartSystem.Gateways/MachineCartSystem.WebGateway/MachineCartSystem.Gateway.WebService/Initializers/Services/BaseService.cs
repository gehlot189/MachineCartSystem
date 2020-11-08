using MachineCartSystem.Gateway.WebService.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace MachineCartSystem.Gateway.WebService.Initializers.Services
{
    public class BaseService : IServiceInitializer
    {
        public void Initialize(IServiceCollection services, IConfiguration configuration)
        {
            services.AddOptions();
            //  services.AddOptions<UrlConfigOptions>().Bind(configuration.GetSection(UrlConfigOptions.Urls));
            //or
            services.Configure<UrlConfigOptions>(configuration.GetSection(UrlConfigOptions.Urls));
            services.Configure<UrlConfigOptions>(configuration.GetSection(UrlConfigOptions.Urls));
        }
    }
}
