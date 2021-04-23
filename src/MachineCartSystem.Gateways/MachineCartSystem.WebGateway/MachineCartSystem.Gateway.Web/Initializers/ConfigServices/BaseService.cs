using MachineCartSystem.Configuration;
using MachineCartSystem.Gateway.WebService.Options;
using MachineCartSystem.Gateway.WebService.Service;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace MachineCartSystem.Gateway.Web.Initializer
{
    public class BaseService : IServiceInitializer
    {
        public void Initialize(IServiceCollection services, IConfiguration configuration)
        {
            services.AddOptions();
            //  services.AddOptions<UrlConfigOptions>().Bind(configuration.GetSection(UrlConfigOptions.Urls));
            //or
            // services.Configure<UrlConfigOptions>(configuration.GetSection(UrlConfigOptions.Urls));

            services.Configure<OpenIdConfiguration>(configuration.GetSection(nameof(OpenIdConfiguration)));
            services.AddSingleton(p => p.GetService<IOptions<OpenIdConfiguration>>().Value);

            services.Configure<GlobalConfiguration>(configuration);
            services.AddSingleton(p => p.GetService<IOptions<GlobalConfiguration>>().Value);

            services.AddSingleton<IConfigurationService, ConfigurationService>();
        }
    }
}
