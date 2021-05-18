namespace MachineCartSystem.Gateway
{
    //[Authorize(AuthenticationSchemes = AuthSchemes.GatewayScheme)]
    public abstract class BaseController<T> : Configuration.BaseController<T> where T : BaseController<T>
    {
    }
}
