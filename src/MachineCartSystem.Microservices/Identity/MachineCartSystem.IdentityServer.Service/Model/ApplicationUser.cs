using Microsoft.AspNetCore.Identity;

namespace MachineCartSystem.IdentityServer.Service.Model
{
    public class ApplicationUser : IdentityUser
    {
        public bool IsEnabled { get; set; }
        public string EmployeeId { get; set; }
    }
}
