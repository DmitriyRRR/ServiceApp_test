using Microsoft.AspNetCore.Identity;

namespace ServiceApp.Database.Models
{
    public class User : IdentityUser
    {
        public string? Initials { get; set; }
    }
}
