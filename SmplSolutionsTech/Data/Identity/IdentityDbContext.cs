using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Duende.IdentityServer.EntityFramework.Options;
using SmplSolutionsTech.Models.Identity;

namespace SmplSolutionsTech.Data.Identity;

public class IdentityDbContext : ApiAuthorizationDbContext<ApplicationUser>
{
    public IdentityDbContext(DbContextOptions options, IOptions<OperationalStoreOptions> operationalStoreOptions)
        : base(options, operationalStoreOptions)
    {
        
    }
}
