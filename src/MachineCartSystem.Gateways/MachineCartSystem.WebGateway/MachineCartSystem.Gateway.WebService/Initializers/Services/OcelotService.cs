using MachineCartSystem.Gateway.WebService.Aggregators;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Ocelot.DependencyInjection;

namespace MachineCartSystem.Gateway.WebService.Initializers.Services
{
    public class OcelotService : IServiceInitializer
    {
        public void Initialize(IServiceCollection services, IConfiguration configuration)
        {
            services.AddOcelot()
                    //.AddCacheManager(x =>
                    //{
                    //    x.WithDictionaryHandle();
                    //})
                    .AddTransientDefinedAggregator<BasketOrderAggregator>();
        }
    }
}
