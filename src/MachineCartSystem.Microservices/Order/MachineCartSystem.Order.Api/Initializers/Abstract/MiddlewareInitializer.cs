using MachineCartSystem.Configuration;
using MachineCartSystem.Configuration.PreInitializer.Middlewares;

namespace MachineCartSystem.Order.Api.Initializer
{
    [ExecutionSequence( nameof(DeveloperExceptionMiddleware),
                        nameof(StaticFilesMiddleware),
                        nameof(CoreMiddleware),
                        nameof(RoutingMiddleware),
                        nameof(HttpsRedirectionMiddleware),
                        nameof(ApiSwaggerMiddleware),
                        nameof(HeaderPropagationMiddleware),
                        nameof(ApiResponseMiddleware),
                        nameof(AuthenticationMiddleware),
                        nameof(AuthorizationMiddleware),
                        nameof(EndpointsMiddleware))]
    public class MiddlewareInitializer : PreMiddlewareInitializer
    {
    }
}
