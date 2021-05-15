using MachineCartSystem.Configuration;

namespace MachineCartSystem.IdentityServer.Initializer
{
    [ExecutionSequence(nameof(SwaggerMiddleware))]
    public class MiddlewareInitializer : PreMiddlewareInitializer
    {

    }
}
