using Microsoft.AspNetCore.Identity;
namespace WebAPIAuth.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; }
    }
}

