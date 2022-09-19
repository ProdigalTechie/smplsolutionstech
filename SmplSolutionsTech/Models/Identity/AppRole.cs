using MessagePack;
using System.ComponentModel.DataAnnotations;

namespace SmplSolutionsTech.Models.Identity
{
    public class AppRole
    {
        public int Id { get; set; }
        [Required]
        public string RoleName { get; set; }

        public List<AppUser> AppUsers { get; set; }
    }
}