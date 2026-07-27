using System.ComponentModel.DataAnnotations;

namespace BankingSystemApi.DTOs
{
    public class CreateCustomerDto
    {
        [Required]
        [StringLength(50, MinimumLength = 10)]
        public string FullName { get; set; } = string.Empty;
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        [Required]
        [Phone]
        public string PhoneNumber { get; set; } = string.Empty;
        [Required]
        public string Address { get; set; } = string.Empty;
    }
}
