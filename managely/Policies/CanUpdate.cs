using Microsoft.AspNetCore.Authorization;

namespace Managely.Policies
{
    public class CanUpdate : IAuthorizationRequirement {}

    public class CanUpdateHandler : AuthorizationHandler<CanUpdate>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, CanUpdate requirement)
        {
            if (context.User.HasClaim(c => c.Type == "Permission" && c.Value.Contains("Update")))
            {
                context.Succeed(requirement);
            }
            else
            {
                context.Fail();
            }
            
            return Task.CompletedTask;
        }
    }
}