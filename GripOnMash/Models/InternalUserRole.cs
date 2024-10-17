using Microsoft.AspNetCore.Identity;

namespace GripOnMash.Models
{
    public class InternalUserRole
    {
        public Guid InternalUserId { get; set; }
        public string RoleId { get; set; }  

        // Navigation properties
        public InternalUser InternalUser { get; set; }
        public IdentityRole Role { get; set; }
    }
}
