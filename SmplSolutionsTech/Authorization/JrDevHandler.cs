using Microsoft.AspNetCore.Authorization;
using SmplSolutionsTech.Helpers.Classes;

namespace SmplSolutionsTech.Authorization
{
    public class JrDevHandler : AuthorizationHandler<JrDevRequirement>
    {
        private readonly IHttpContextAccessor _httpContext;
        public JrDevHandler(IHttpContextAccessor httpContext)
        {
            _httpContext = httpContext;
        }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, JrDevRequirement requirement)
        {
            if (context.User.HasJrDevAccess()) context.Succeed(requirement);
            return Task.CompletedTask;
        } 
    }
}
