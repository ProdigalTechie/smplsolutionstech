using SmplSolutionsTech.Helpers.Enums;
using System.Security.Claims;

namespace SmplSolutionsTech.Helpers.Classes
{
    public static class UserHelper
    {
        public static bool HasFullSiteAccess(this ClaimsPrincipal user)
        {
            return user.HasClaim(x => x.Value == nameof(AppRolesEnum.Admin));
        }

        public static bool HasSrDevAccess(this ClaimsPrincipal user)
        {
            return user.HasClaim(x => x.Value == nameof(AppRolesEnum.SrDev) || x.Value == nameof(AppRolesEnum.Admin));
        }

        public static bool HasMidDevAccess(this ClaimsPrincipal user)
        {
            return user.HasClaim(x => x.Value == nameof(AppRolesEnum.MidDev) || x.Value == nameof(AppRolesEnum.SrDev) || x.Value == nameof(AppRolesEnum.Admin));
        }

        public static bool HasJrDevAccess(this ClaimsPrincipal user)
        {
            return user.HasClaim(x => x.Value == nameof(AppRolesEnum.JrDev) || x.Value == nameof(AppRolesEnum.MidDev) || x.Value == nameof(AppRolesEnum.SrDev) || x.Value == nameof(AppRolesEnum.Admin));
        }
    }
}
