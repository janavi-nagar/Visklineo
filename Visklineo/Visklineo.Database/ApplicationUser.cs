using Microsoft.AspNetCore.Identity;

namespace Visklineo.Database
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}