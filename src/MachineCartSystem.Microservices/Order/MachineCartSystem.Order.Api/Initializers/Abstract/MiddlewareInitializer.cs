using MachineCartSystem.Configuration;

namespace MachineCartSystem.Order.Api.Initializer
{
    [ExecutionSequence(nameof(SwaggerMiddleware))]
    public class MiddlewareInitializer : PreMiddlewareInitializer
    {

    }
}
