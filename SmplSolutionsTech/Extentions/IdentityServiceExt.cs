using Common.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using SmplSolutionsTech.Authorization;
using SmplSolutionsTech.Data.Identity;
using SmplSolutionsTech.Helpers.Classes;
using SmplSolutionsTech.Helpers.Enums;
using SmplSolutionsTech.Models.Identity;

namespace SmplSolutionsTech.Extentions
{
    public static class IdentityServiceExt
    {
        public static IServiceCollection AddIdentityServices(this IServiceCollection services,
            IConfiguration config)
        {
            var connectionString = config.GetConnectionString("AppIdentityDbContextConnection") 
                ?? throw new InvalidOperationException("Connection string 'AppIdentityDbContextConnection' not found.");

            var builder = services.AddDbContext<AppIdentityDbContext>(options =>
                options.UseSqlServer(connectionString));

            builder.AddDefaultIdentity<AppUser>(options =>
            {
                options.SignIn.RequireConfirmedAccount = true;
                options.Tokens.ProviderMap.Add("CustomEmailConfirmation",
                    new TokenProviderDescriptor(
                        typeof(CustomEmailConfirmationTokenProvider<AppUser>)));
                options.Tokens.EmailConfirmationTokenProvider = "CustomEmailConfirmation";
            }).AddEntityFrameworkStores<AppIdentityDbContext>()
                .AddSignInManager<SignInManagerExt>()
                .AddUserManager<UserManager<AppUser>>()
                .AddClaimsPrincipalFactory<ClaimsPrincipalFactoryExt>();

            builder.AddTransient<CustomEmailConfirmationTokenProvider<AppUser>>();

            builder.Configure<DataProtectionTokenProviderOptions>(x => x.TokenLifespan = TimeSpan.FromHours(2));

            builder.Configure<IdentityOptions>(options =>
            {
                // Password settings.
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 8;
                options.Password.RequiredUniqueChars = 1;

                // Lockout settings.
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;

                // User settings.
                options.User.AllowedUserNameCharacters =
                "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
                options.User.RequireUniqueEmail = true;
            });

            builder.ConfigureApplicationCookie(options =>
            {
                // Cookie settings
                options.ExpireTimeSpan = TimeSpan.FromDays(5);

                options.LoginPath = "/Identity/Account/Login";
                options.AccessDeniedPath = "/Identity/Account/AccessDenied";
                options.SlidingExpiration = true;
            });

            builder.Configure<DataProtectionTokenProviderOptions>(o =>
                o.TokenLifespan = TimeSpan.FromHours(3));

            builder.AddAuthorization(options =>
            {
                options.AddPolicy(nameof(AuthorizationPolicies.Admin), policy => policy.Requirements.Add(new AdminRequirement()));
                options.AddPolicy(nameof(AuthorizationPolicies.SrDev), policy => policy.Requirements.Add(new SrDevRequirement()));
                options.AddPolicy(nameof(AuthorizationPolicies.MidDev), policy => policy.Requirements.Add(new MidDevRequirement()));
                options.AddPolicy(nameof(AuthorizationPolicies.JrDev), policy => policy.Requirements.Add(new JrDevRequirement()));
            });

            builder.AddSingleton<IAuthorizationHandler, AdminHandler>();
            builder.AddSingleton<IAuthorizationHandler, SrDevHandler>();
            builder.AddSingleton<IAuthorizationHandler, MidDevHandler>();
            builder.AddSingleton<IAuthorizationHandler, JrDevHandler>();

            return services;
        }
    }
}
