using MachineCartSystem.Configuration;

namespace MachineCartSystem.Gateway.Web.Initializer
{
    [ExecutionSequence(nameof(ContollerService),
                       nameof(CoreService),
                       nameof(ApplicationService),
                       nameof(AutoMapperService),
                       nameof(BaseService),
                       nameof(OcelotService),
                       nameof(AuthenticationService),
                       nameof(GatewaySwaggerService))]
    public class ServiceInitializer : PreServiceInitializer
    {
    }
}
