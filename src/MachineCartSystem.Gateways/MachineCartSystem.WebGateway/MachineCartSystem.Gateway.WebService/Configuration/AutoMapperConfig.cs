using AutoMapper;
using MachineCartSystem.Configuration;

namespace MachineCartSystem.Gateway.WebService
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<GlobalConfiguration, BasketConfig>()
                .ForMember(p => p.Audiences, q => q.MapFrom(r => r.Basket.Audiences))
                .ForMember(p => p.Scope, q => q.MapFrom(r => r.Basket.Scope))
                .ForMember(p => p.PrivateKey, q => q.MapFrom(r => r.Basket.PrivateKey))
                .ForMember(p => p.Url, q => q.MapFrom(r => r.Basket.Url));


        }
    }
}
