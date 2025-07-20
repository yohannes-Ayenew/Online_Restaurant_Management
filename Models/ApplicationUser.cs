using Microsoft.AspNetCore.Identity;

namespace Online_Restaurant_Management.Models

{
    public class ApplicationUser : IdentityUser
    {
        public ICollection<Order>? Orders { get; set; }   
    }
}
