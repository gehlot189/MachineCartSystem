using AutoMapper;

namespace MachineCartSystem.Configuration
{
    public class GlobalConfigurationProfile : Profile
    {
        public GlobalConfigurationProfile()
        {
            CreateMap<GlobalConfiguration, ClientConfiguration>()
                .ForPath(p => p.OpenIdConfiguration.StsServer, q => q.MapFrom(r => r.GatewayUrl))
                .ForPath(p => p.OpenIdConfiguration.Scope, q => q.MapFrom(r => r.Gateway.Scopes))
                .AfterMap((p, q) =>
                {
                    if (!q.OpenIdConfiguration.RedirectUrl.StartsWith(q.Url))
                        q.OpenIdConfiguration.RedirectUrl = q.Url + q.OpenIdConfiguration.RedirectUrl;
                    if (!q.OpenIdConfiguration.PostLogoutRedirectUri.StartsWith(q.Url))
                        q.OpenIdConfiguration.PostLogoutRedirectUri = q.Url + q.OpenIdConfiguration.PostLogoutRedirectUri;
                    if (!q.OpenIdConfiguration.SilentRenewUrl.StartsWith(q.Url))
                        q.OpenIdConfiguration.SilentRenewUrl = q.Url + q.OpenIdConfiguration.SilentRenewUrl;
                });

            CreateMap<GlobalConfiguration, GlobalConfiguration>()
                .ForMember(p => p.GatewayUrl, q => q.MapFrom(r => r.Gateway.Url))
                .ForMember(p => p.IdentityServerUrl, q => q.MapFrom(r => r.Identity.Url))
                .ForMember(p => p.Issuer, q => q.MapFrom(r => r.Identity.Issuer))
                .ForMember(p => p.Authority, q => q.MapFrom(r => r.Identity.Authority));

            CreateMap<GlobalConfiguration, GatewayConfig>()
                .ForMember(p => p.PrivateKey, q => q.MapFrom(r => r.Gateway.PrivateKey))
                .ForMember(p => p.Url, q => q.MapFrom(r => r.Gateway.Url))
                .ForMember(p => p.Name, q => q.MapFrom(_ => ApiName.Gateway.ToString()))
                .ForMember(p => p.Description, q => q.MapFrom(_ => ApiName.Gateway.GetDescription()));

            CreateMap<GlobalConfiguration, IdentityConfig>()
                .ForMember(p => p.Audiences, q => q.MapFrom(r => r.Identity.Audiences))
                .ForMember(p => p.Scopes, q => q.MapFrom(r => r.Identity.Scopes))
                .ForMember(p => p.PrivateKey, q => q.MapFrom(r => r.Identity.PrivateKey))
                .ForMember(p => p.Url, q => q.MapFrom(r => r.Identity.Url))
                .ForMember(p => p.Name, q => q.MapFrom(_ => ApiName.Identity.ToString()))
                .ForMember(p => p.Description, q => q.MapFrom(_ => ApiName.Identity.GetDescription()));

            CreateMap<GlobalConfiguration, BasketConfig>()
                .ForMember(p => p.Audiences, q => q.MapFrom(r => r.Basket.Audiences))
                .ForMember(p => p.Scopes, q => q.MapFrom(r => r.Basket.Scopes))
                .ForMember(p => p.PrivateKey, q => q.MapFrom(r => r.Basket.PrivateKey))
                .ForMember(p => p.Url, q => q.MapFrom(r => r.Basket.Url))
                .ForMember(p => p.Name, q => q.MapFrom(_ => ApiName.Basket.ToString()))
                .ForMember(p => p.Description, q => q.MapFrom(_ => ApiName.Basket.GetDescription()));

            CreateMap<GlobalConfiguration, CatalogConfig>()
               .ForMember(p => p.Audiences, q => q.MapFrom(r => r.Catalog.Audiences))
               .ForMember(p => p.Scopes, q => q.MapFrom(r => r.Catalog.Scopes))
               .ForMember(p => p.PrivateKey, q => q.MapFrom(r => r.Catalog.PrivateKey))
               .ForMember(p => p.Url, q => q.MapFrom(r => r.Catalog.Url))
               .ForMember(p => p.Name, q => q.MapFrom(_ => ApiName.Catalog.ToString()))
               .ForMember(p => p.Description, q => q.MapFrom(_ => ApiName.Catalog.GetDescription()));

            CreateMap<GlobalConfiguration, OrderConfig>()
               .ForMember(p => p.Audiences, q => q.MapFrom(r => r.Order.Audiences))
               .ForMember(p => p.Scopes, q => q.MapFrom(r => r.Order.Scopes))
               .ForMember(p => p.PrivateKey, q => q.MapFrom(r => r.Order.PrivateKey))
               .ForMember(p => p.Url, q => q.MapFrom(r => r.Order.Url))
               .ForMember(p => p.Name, q => q.MapFrom(_ => ApiName.Order.ToString()))
               .ForMember(p => p.Description, q => q.MapFrom(_ => ApiName.Order.GetDescription()));
        }
    }
}
