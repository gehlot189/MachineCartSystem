using Microsoft.AspNetCore.Authorization;

namespace MachineCartSystem.Configuration
{
    public class PolicyApplier
    {
        public string PoliyName { get; set; }
        public bool IsRequireAuthenticatedUser { get; set; }
        public IAuthorizationRequirement[] AuthorizationRequirements { get; set; }
    }
}
