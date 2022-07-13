using Microsoft.AspNetCore.Authorization;

namespace Managely.Policies
{
    public class CanRead : IAuthorizationRequirement {}

    public class CanReadHandler : AuthorizationHandler<CanRead>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, CanRead requirement)
        {
            if (context.User.HasClaim(c => c.Type == "Permission" && c.Value.Contains("Read")))
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