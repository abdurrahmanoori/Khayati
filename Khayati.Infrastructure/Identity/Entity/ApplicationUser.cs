using Microsoft.AspNetCore.Identity;

namespace Khayati.Infrastructure.Identity.Entity
{
    public class ApplicationUser:IdentityUser<int>
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
    }
}
