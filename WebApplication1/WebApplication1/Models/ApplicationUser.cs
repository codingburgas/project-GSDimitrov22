using Microsoft.AspNetCore.Identity;

namespace CarpoolingApp.Models
{
    public class ApplicationUser : IdentityUser
    {
        // Stores the user's full name
        public string FullName { get; set; } = "";
    }
}
