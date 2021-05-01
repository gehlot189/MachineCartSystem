using MachineCartSystem.Gateway.Web.HttpAggregators;
using Microsoft.Extensions.DependencyInjection;
using Ocelot.Cache.CacheManager;
using Ocelot.DependencyInjection;

namespace MachineCartSystem.Gateway.Web.Initializer
{
    public class OcelotService : ServiceInitializer
    {
        public override void Initialize(IServiceCollection services)
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
