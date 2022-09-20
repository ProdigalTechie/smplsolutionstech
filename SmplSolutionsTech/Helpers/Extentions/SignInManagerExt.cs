using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using SmplSolutionsTech.Models.Identity;

namespace Common.Extensions
{
	public class SignInManagerExt : SignInManager<AppUser>
	{
		private readonly IUserClaimsPrincipalFactory<AppUser> _claimsFactory;
		private readonly ILogger<SignInManagerExt> _logger;

		public SignInManagerExt(UserManager<AppUser> userManager, IHttpContextAccessor contextAccessor, IUserClaimsPrincipalFactory<AppUser> claimsFactory,
			IOptions<IdentityOptions> optionsAccessor, ILogger<SignInManagerExt> logger, IAuthenticationSchemeProvider schemeProvider, IUserConfirmation<AppUser> confirmation)
			: base(userManager, contextAccessor, claimsFactory, optionsAccessor, logger, schemeProvider, confirmation)
		{
			_claimsFactory = claimsFactory;
			_logger = logger;
		}

		public async Task<SignInResult> PasswordSignInAsync(string userName, string password)
		{
			// display error if username or password is left blank
			if (!string.IsNullOrEmpty(userName) && !string.IsNullOrEmpty(password))
			{
				try
				{
					var user = await UserManager.FindByNameAsync(userName);
					var signInResult = await base.PasswordSignInAsync(userName, password, true, false);
					if (!signInResult.Succeeded)
					{
						// TODO revisit after adding serilog
						//_logger.LogError($"User: {userName}, login failed. {CommonResource.UsernameOrPasswordIsIncorrect}");
						throw new ApplicationException();
					}
                    return signInResult;
                }
				catch (ApplicationException ax)
				{
					throw ax;
				}
				catch (Exception e)
				{
					//_logger.LogError($"User: {userName}, login failed. {e.Message}");
					throw new ApplicationException();
				}
			}
			else
			{
				//_logger.LogError($"User: {userName}, login failed. {CommonResource.UsernameOrPasswordIsIncorrect}");
				throw new ApplicationException();
			}
		}
	}
}