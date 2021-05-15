using MachineCartSystem.Configuration;

namespace MachineCartSystem.Gateway.Web.Initializer
{
    [ExecutionSequence(nameof(SwaggerMiddleware), nameof(OcelotMiddleware))]
    public class MiddlewareInitializer : PreMiddlewareInitializer { }
}
