using Microsoft.AspNetCore.Authorization;

namespace Managely.Policies
{
    public class CanCreate : IAuthorizationRequirement {}

    public class CanCreateHandler : AuthorizationHandler<CanCreate>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, CanCreate requirement)
        {
            if (context.User.HasClaim(c => c.Type == "Permission" && c.Value.Contains("Create")))
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