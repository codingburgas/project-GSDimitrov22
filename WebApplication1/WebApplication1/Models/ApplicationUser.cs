using Microsoft.AspNetCore.Identity;

namespace CarpoolingApp.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; } = "";
    }
}
