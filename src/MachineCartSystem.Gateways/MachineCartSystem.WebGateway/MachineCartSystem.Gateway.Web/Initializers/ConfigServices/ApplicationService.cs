using MachineCartSystem.Gateway.WebService;
using MachineCartSystem.Gateway.WebService.Model.OpenIdConfiguration;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace MachineCartSystem.Gateway.Web.Initializer
{
    public class ApplicationService : IServiceInitializer
    {
        public void Initialize(IServiceCollection services, IConfiguration configuration)
        {
            ////register delegating handlers
            services.AddTransient<HttpClientAuthorizationDelegatingHandler>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            ////register http services

            services.AddHttpClient<IBasketService, BasketService>()
                .AddHttpMessageHandler<HttpClientAuthorizationDelegatingHandler>();
            //.AddDevspacesSupport();

            services.Configure<OpenIdConfiguration>(configuration.GetSection("openIdConfiguration"));
            services.AddSingleton(p => p.GetService<IOptions<OpenIdConfiguration>>().Value);

            //services.AddHttpClient<ICatalogService, CatalogService>()
            //    .AddDevspacesSupport();

            //services.AddHttpClient<IOrderApiClient, OrderApiClient>()
            //    .AddHttpMessageHandler<HttpClientAuthorizationDelegatingHandler>()
            //    .AddDevspacesSupport();

            //services.AddHttpClient<IOrderingService, OrderingService>()
            //    .AddHttpMessageHandler<HttpClientAuthorizationDelegatingHandler>()
            //    .AddDevspacesSupport();
        }
    }
}
