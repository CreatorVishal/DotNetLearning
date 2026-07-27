using System.ComponentModel.DataAnnotations;

namespace BankingSystemApi.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50,MinimumLength = 10)]
        public string FullName { get; set; } = string.Empty;
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        [Required]
        [Phone]
        public string PhoneNumber { get; set; } = string.Empty;
        [Required]

        public string Address { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; }
        public bool isActive { get; set; }
    }
}
