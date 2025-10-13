using Microsoft.AspNetCore.Identity;

namespace LibrarySystem.Models
{
    public class ApplicationUser : IdentityUser
    {
        public required string FirstName { set; get; }
        public required string LastName { set; get; }
    }
}
