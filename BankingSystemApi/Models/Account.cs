

using System.ComponentModel.DataAnnotations;

namespace BankingSystemApi.Models
{
    public class Account
    {
        public int Id { get; set; }
        [Required]
        [StringLength(20)]
        public string AccountNumber { get; set; }= string.Empty;
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string AccountHolderName { get; set; } = string.Empty;
        [Range(1000, 10000000)]
        public decimal Balance { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        [Required]
        [Phone]
        public string PhoneNumber { get; set; }= string.Empty;
        public DateTime CreatedAt { get; set; }
        public Boolean IsActive { get; set; }
    }
}
