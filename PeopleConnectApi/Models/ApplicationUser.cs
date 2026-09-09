using Microsoft.AspNetCore.Identity;

namespace PeopleConnectApi.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; }

        public bool IsActive { get; set; } = true;
        public string Department { get; set; } = string.Empty;
    }
}