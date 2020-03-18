using AutoMapper;
using MachineCartSystem.Entity.DomainModel;
using MachineCartSystem.Entity.UserInfo;

namespace MachineCartSystem.Service
{
    public class AutoMapperConfig
    {
        public class UserProfile : Profile
        {
            public UserProfile()
            {
                CreateMap<UserDetail, UserDetailVM>().ReverseMap();
            }
        }
    }
}
