using MachineCartSystem.Configuration;

namespace MachineCartSystem.Catalog.Api.Initializer
{
    [ExecutionSequence(nameof(SwaggerMiddleware))]
    public class MiddlewareInitializer : PreMiddlewareInitializer
    {

    }
}
