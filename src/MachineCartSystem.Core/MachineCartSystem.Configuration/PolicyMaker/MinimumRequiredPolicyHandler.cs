using Microsoft.AspNetCore.Authorization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MachineCartSystem.Configuration
{
    public class MinimumRequiredPolicyHandler : IAuthorizationHandler
    {
        public Task HandleAsync(AuthorizationHandlerContext context)
        {

            if (!context.User.Identity.IsAuthenticated)
            {
                return Task.CompletedTask;
            }
            if (context.HasSucceeded)
            {
                return Task.CompletedTask;
            }
            //if (context.User.IsInRole("Super Admin"))
            //{
            //    Utility.Succeed(context, requirement.Identifier);
            //    return Task.CompletedTask;
            //}
            var pendingRequirements = context.PendingRequirements.ToList();

            foreach (var requirement in pendingRequirements)
            {
                if (context.User.HasClaim(p => p.Type == ClaimTypes.Role))
                {
                    context.Succeed(requirement);
                }
            }
            return Task.CompletedTask;
        }
    }
}
