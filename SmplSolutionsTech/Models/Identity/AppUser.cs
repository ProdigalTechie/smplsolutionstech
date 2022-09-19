using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Build.Framework;

namespace SmplSolutionsTech.Models.Identity;

// Add profile data for application users by adding properties to the AppUser class
public class AppUser : IdentityUser
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int UserId { get; set; }

    public int AppRoleId { get; set; }
    public AppRole AppRole { get; set; }

    public Address Address { get; set; }
}

