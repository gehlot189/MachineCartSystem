using MachineCartSystem.Configuration;

namespace MachineCartSystem.Basket.Api.Initializer
{
    [ExecutionSequence( nameof(ContollerService),
                        nameof(CoreService),
                        nameof(ApplicationService),
                        nameof(AutoMapperService),
                        nameof(BaseService),
                        nameof(ApiAuthenticationService),
                        nameof(ApiSwaggerService))]
    public class ServiceInitializer : PreServiceInitializer
    {
    }
}
