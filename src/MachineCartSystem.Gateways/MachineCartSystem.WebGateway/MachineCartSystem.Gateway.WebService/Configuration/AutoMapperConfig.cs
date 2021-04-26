﻿using AutoMapper;
using MachineCartSystem.Configuration;

namespace MachineCartSystem.Gateway.WebService
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<GlobalConfiguration, IdentityConfig>()
               .ForMember(p => p.Audiences, q => q.MapFrom(r => r.Identity.Audiences))
               .ForMember(p => p.Scopes, q => q.MapFrom(r => r.Identity.Scopes))
               .ForMember(p => p.PrivateKey, q => q.MapFrom(r => r.Identity.PrivateKey))
               .ForMember(p => p.Url, q => q.MapFrom(r => r.Identity.Url));

            CreateMap<GlobalConfiguration, BasketConfig>()
                .ForMember(p => p.Audiences, q => q.MapFrom(r => r.Basket.Audiences))
                .ForMember(p => p.Scopes, q => q.MapFrom(r => r.Basket.Scopes))
                .ForMember(p => p.PrivateKey, q => q.MapFrom(r => r.Basket.PrivateKey))
                .ForMember(p => p.Url, q => q.MapFrom(r => r.Basket.Url));

            CreateMap<GlobalConfiguration, CatalogConfig>()
               .ForMember(p => p.Audiences, q => q.MapFrom(r => r.Catalog.Audiences))
               .ForMember(p => p.Scopes, q => q.MapFrom(r => r.Catalog.Scopes))
               .ForMember(p => p.PrivateKey, q => q.MapFrom(r => r.Catalog.PrivateKey))
               .ForMember(p => p.Url, q => q.MapFrom(r => r.Catalog.Url));

            CreateMap<GlobalConfiguration, OrderConfig>()
               .ForMember(p => p.Audiences, q => q.MapFrom(r => r.Order.Audiences))
               .ForMember(p => p.Scopes, q => q.MapFrom(r => r.Order.Scopes))
               .ForMember(p => p.PrivateKey, q => q.MapFrom(r => r.Order.PrivateKey))
               .ForMember(p => p.Url, q => q.MapFrom(r => r.Order.Url));
        }
    }
}
