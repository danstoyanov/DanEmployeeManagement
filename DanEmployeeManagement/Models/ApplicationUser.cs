using Microsoft.AspNetCore.Identity;

namespace DanEmployeeManagement.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string City { get; set; }
    }
}
