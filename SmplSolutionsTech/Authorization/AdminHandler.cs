using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

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
            throw new NotImplementedException();
        }
    }
}
