using Microsoft.AspNetCore.Authorization;
using SmplSolutionsTech.Helpers.Classes;

namespace SmplSolutionsTech.Authorization
{
    public class SrDevHandler : AuthorizationHandler<SrDevRequirement>
    {
        private readonly IHttpContextAccessor _httpContext;
        public SrDevHandler(IHttpContextAccessor httpContext)
        {
            _httpContext = httpContext;
        }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, SrDevRequirement requirement)
        {
            if (context.User.HasSrDevAccess()) context.Succeed(requirement);
            return Task.CompletedTask;
        } 
    }
}
