using Microsoft.AspNetCore.Identity;

namespace SmplSolutionsTech.Models.Identity;

// Add profile data for application users by adding properties to the AppUser class
public class AppUser : IdentityUser
{
    public int AppRoleId { get; set; }
    public AppRole AppRole { get; set; }

    public Address Address { get; set; }
}

