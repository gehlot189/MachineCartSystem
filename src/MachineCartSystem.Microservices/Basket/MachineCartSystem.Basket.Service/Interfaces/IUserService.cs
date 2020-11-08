using MachineCartSystem.Entity.UserInfo;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MachineCartSystem.Service.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserDetailVM>> GetAllUserDetailAsync();
        Task AddUserDetailAsync(UserDetailVM userDetail);
        Task UpdateUserDetailAsync(UserDetailVM userDetail);

    }
}
