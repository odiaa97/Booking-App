using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace API.Entities
{
    public class AppRole : IdentityRole<int>
    {
        public AppUser User { get; set; }
        public ICollection<AppUserRole> UserRoles { get; set; }
    }
}