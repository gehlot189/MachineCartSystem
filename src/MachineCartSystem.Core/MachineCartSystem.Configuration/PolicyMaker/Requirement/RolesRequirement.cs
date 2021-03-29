using Microsoft.AspNetCore.Authorization;
using System;

namespace MachineCartSystem.Configuration.PolicyMaker.Requirement
{
    public class RolesRequirement : IAuthorizationRequirement, IIdentifiable
    {
        public RolesRequirement(string roles, Guid identifier)
        {
            Roles = roles;
            Identifier = identifier;
        }

        public string Roles { get; }

        public Guid Identifier { get; set; }
    }
}
