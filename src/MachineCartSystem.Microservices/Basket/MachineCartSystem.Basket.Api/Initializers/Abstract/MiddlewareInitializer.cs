using MachineCartSystem.Configuration;

namespace MachineCartSystem.Basket.Api.Initializer
{
    [ExecutionSequence(nameof(SwaggerMiddleware))]
    public class MiddlewareInitializer : PreMiddlewareInitializer
    {

    }
}
