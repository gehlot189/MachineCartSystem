using MachineCartSystem.Configuration;

namespace MachineCartSystem.IdentityServer.Initializer
{
    [ExecutionSequence( nameof(ContollerService),
                        nameof(CoreService),
                        nameof(ApplicationService),
                        nameof(AutoMapperService),
                        nameof(BaseService),
                        nameof(AuthenticationService),
                        nameof(IdentitySwaggerService), 
                        nameof(IdentityServerService))]
    public class ServiceInitializer : PreServiceInitializer
    {
    }
}
