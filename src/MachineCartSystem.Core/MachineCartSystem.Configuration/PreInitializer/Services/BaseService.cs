using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace MachineCartSystem.Configuration
{
    public class BaseService : PreServiceInitializer
    {
        public override void PreInitialize(IServiceCollection services, IConfiguration configuration)
        {
            services.AddOptions();
            //  services.AddOptions<UrlConfigOptions>().Bind(configuration.GetSection(UrlConfigOptions.Urls));
            //or
            // services.Configure<UrlConfigOptions>(configuration.GetSection(UrlConfigOptions.Urls));

            services.Configure<ClientConfiguration>(configuration.GetSection(nameof(ClientConfiguration)));
            services.AddSingleton(p => p.GetService<IOptions<ClientConfiguration>>().Value);

            services.Configure<GlobalConfiguration>(configuration);
            services.AddSingleton(p => p.GetService<IOptions<GlobalConfiguration>>().Value);
        }
    }
}
