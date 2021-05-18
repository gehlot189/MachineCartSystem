using MachineCartSystem.Configuration;
using MachineCartSystem.Configuration.PreInitializer.Middlewares;

namespace MachineCartSystem.IdentityServer.Initializer
{
    [ExecutionSequence( nameof(DeveloperExceptionMiddleware),
                        nameof(StaticFilesMiddleware),
                        nameof(CoreMiddleware),
                        nameof(RoutingMiddleware),
                        nameof(HttpsRedirectionMiddleware),
                        nameof(IdentitySwaggerMiddleware),
                        nameof(HeaderPropagationMiddleware),
                        nameof(ApiResponseMiddleware),
                        nameof(IdentityServerMiddleware),
                        nameof(AuthenticationMiddleware),
                        nameof(CookiePolicyMiddleware),
                        nameof(AuthorizationMiddleware),
                        nameof(EndpointsMiddleware))]
    public class MiddlewareInitializer : PreMiddlewareInitializer
    {

    }
}
