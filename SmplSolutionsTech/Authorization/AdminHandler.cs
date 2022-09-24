using Microsoft.AspNetCore.Authorization;
using SmplSolutionsTech.Helpers.Classes;

namespace SmplSolutionsTech.Authorization
{
    public class AdminHandler : AuthorizationHandler<AdminRequirement>
    {
        private readonly IHttpContextAccessor _httpContext;

        public AdminHandler(IHttpContextAccessor httpContext)
        {
            _httpContext = httpContext;
        }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, AdminRequirement requirement)
        {
            if (context.User.HasFullSiteAccess()) context.Succeed(requirement);
            return Task.CompletedTask;
        } 
    }
}
