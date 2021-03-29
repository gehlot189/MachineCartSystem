using Microsoft.AspNetCore.Authorization;
using System;

namespace MachineCartSystem.Configuration.PolicyMaker.Requirement
{
    public class PermissionsRequirement : IAuthorizationRequirement, IIdentifiable
    {
        public PermissionsRequirement(string permissions, Guid identifier)
        {
            Permissions = permissions;
            Identifier = identifier;
        }

        public string Permissions { get; }
        public Guid Identifier { get; set; }
    }
}
