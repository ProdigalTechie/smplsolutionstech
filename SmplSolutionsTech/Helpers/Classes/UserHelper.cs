using SmplSolutionsTech.Helpers.Enums;
using System.Security.Claims;

namespace SmplSolutionsTech.Helpers.Classes
{
    public static class UserHelper
    {
        public static bool HasFullSiteAccess(this ClaimsPrincipal user)
        {
            return user.HasClaim(x => x.Value == nameof(AppRoles.Admin));
        }

        public static bool HasSrDevAccess(this ClaimsPrincipal user)
        {
            return user.HasClaim(x => x.Value == nameof(AppRoles.SrDev) || x.Value == nameof(AppRoles.Admin));
        }

        public static bool HasMidDevAccess(this ClaimsPrincipal user)
        {
            return user.HasClaim(x => x.Value == nameof(AppRoles.MidDev) || x.Value == nameof(AppRoles.SrDev) || x.Value == nameof(AppRoles.Admin));
        }

        public static bool HasJrDevAccess(this ClaimsPrincipal user)
        {
            return user.HasClaim(x => x.Value == nameof(AppRoles.JrDev) || x.Value == nameof(AppRoles.MidDev) || x.Value == nameof(AppRoles.SrDev) || x.Value == nameof(AppRoles.Admin));
        }
    }
}
