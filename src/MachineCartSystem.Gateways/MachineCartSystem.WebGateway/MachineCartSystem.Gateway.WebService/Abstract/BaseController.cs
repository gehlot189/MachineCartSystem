using MachineCartSystem.Configuration;
using Microsoft.AspNetCore.Authorization;

namespace MachineCartSystem.Gateway
{
    [Authorize(AuthenticationSchemes = AuthSchemes.GatewayScheme)]
    public abstract class BaseController<T> : MachineCartSystem.Configuration.BaseController<T> where T : BaseController<T>
    {
    }
}
