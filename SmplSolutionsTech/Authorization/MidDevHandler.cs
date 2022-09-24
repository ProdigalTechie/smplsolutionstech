using Microsoft.AspNetCore.Authorization;
using SmplSolutionsTech.Helpers.Classes;

namespace SmplSolutionsTech.Authorization
{
    public class MidDevHandler : AuthorizationHandler<MidDevRequirement>
    {
        private readonly IHttpContextAccessor _httpContext;
        public MidDevHandler(IHttpContextAccessor httpContext)
        {
            _httpContext = httpContext;
        }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, MidDevRequirement requirement)
        {
            if (context.User.HasMidDevAccess()) context.Succeed(requirement);
            return Task.CompletedTask;
        } 
    }
}
