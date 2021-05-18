using MachineCartSystem.Configuration;
using MachineCartSystem.Configuration.PreInitializer.Middlewares;

namespace MachineCartSystem.Gateway.Web.Initializer
{
    [ExecutionSequence(nameof(DeveloperExceptionMiddleware),
                       nameof(StaticFilesMiddleware),
                       nameof(CoreMiddleware),
                       nameof(RoutingMiddleware),
                       nameof(HttpsRedirectionMiddleware),
                       nameof(GatewaySwaggerMiddleware),
                       nameof(HeaderPropagationMiddleware),
                       nameof(ApiResponseMiddleware),
                       nameof(AuthenticationMiddleware),
                       nameof(AuthorizationMiddleware),
                       nameof(EndpointsMiddleware),
                       nameof(OcelotMiddleware))]
    public class MiddlewareInitializer : PreMiddlewareInitializer { }
}
