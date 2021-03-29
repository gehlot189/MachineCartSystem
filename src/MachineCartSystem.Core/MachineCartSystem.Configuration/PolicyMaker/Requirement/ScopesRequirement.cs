using Microsoft.AspNetCore.Authorization;
using System;

namespace MachineCartSystem.Configuration.PolicyMaker.Requirement
{
    public class ScopesRequirement : IAuthorizationRequirement, IIdentifiable
    {
        public ScopesRequirement(string scopes, Guid identifier)
        {
            Scopes = scopes;
            Identifier = identifier;
        }

        public string Scopes { get; }

        public Guid Identifier { get; set; }
    }
}
