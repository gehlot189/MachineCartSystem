using MachineCartSystem.Configuration;
using MachineCartSystem.Service.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace MachineCartSystem.BasketApi
{
    public abstract class BasketBaseController<T> : BaseController<T> where T : BaseController<T>
    {
        private IUserService _userService;

        protected IUserService UserService => _userService ?? (_userService =
            HttpContext.RequestServices.GetService<IUserService>());
    }
}
