using Microsoft.AspNetCore.Identity;
using Task.Data.Models.App;

namespace Task.Data.Models.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public string? Address { get; set; }
        public string FullName { get; set; }
        public ICollection<Order>? Orders { get; set; }

    }
}
