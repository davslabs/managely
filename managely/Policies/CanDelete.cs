using Microsoft.AspNetCore.Authorization;

namespace Managely.Policies
{
    public class CanDelete : IAuthorizationRequirement {}
    
    public class CanDeleteHandler : AuthorizationHandler<CanDelete>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, CanDelete requirement)
        {
            if (context.User.HasClaim(c => c.Type == "Permission" && c.Value.Contains("Delete")))
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