using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using SmplSolutionsTech.Helpers.Enums;
using SmplSolutionsTech.Models.Identity;
using System.Security.Claims;

namespace Common.Extensions
{
	public class ClaimsPrincipalFactoryExt : UserClaimsPrincipalFactory<AppUser>
	{
		public ClaimsPrincipalFactoryExt(UserManager<AppUser> userManager, IOptions<IdentityOptions> optionsAccessor) : base(userManager, optionsAccessor)
		{
		}

		protected override async Task<ClaimsIdentity> GenerateClaimsAsync(AppUser user)
		{
			var claims = await base.GenerateClaimsAsync(user);

			claims.AddClaim(new Claim(ClaimTypes.Sid, $"{user.Id ?? user.Id}"));
			claims.AddClaim(new Claim(ClaimTypes.Name, $"{user.UserName}"));
			claims.AddClaim(new Claim(ClaimTypes.Role, $"{(AppRoles)user.AppRoleId}"));

			return claims;
		}
	}
}
