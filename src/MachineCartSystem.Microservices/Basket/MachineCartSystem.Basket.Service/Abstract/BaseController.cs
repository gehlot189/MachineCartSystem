using MachineCartSystem.Service.Interfaces;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.DependencyInjection;

namespace MachineCartSystem.BasketApi
{
    public abstract class BaseController<T> : MachineCartSystem.Configuration.BaseController<T> where T : BaseController<T>
    {
        private IUserService _userService;

        protected IUserService UserService => _userService ?? (_userService =
            HttpContext.RequestServices.GetService<IUserService>());
    }
}
