using MachineCartSystem.Gateway.Web.HttpAggregators;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Ocelot.Cache.CacheManager;
using Ocelot.DependencyInjection;

namespace MachineCartSystem.Gateway.Web.Initializer
{
    public class OcelotService : IServiceInitializer
    {
        public void Initialize(IServiceCollection services, IConfiguration configuration)
        {
            services.AddOcelot()
                    .AddCacheManager(x =>
                    {
                        x.WithDictionaryHandle();
                    })
                    .AddTransientDefinedAggregator<BasketOrderAggregator>()
                    .AddTransientDefinedAggregator<CatalogAggregator>();

        }
    }
}
