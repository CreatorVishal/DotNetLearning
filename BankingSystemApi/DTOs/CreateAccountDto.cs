using System.ComponentModel.DataAnnotations;

namespace BankingSystemApi.DTOs
{
    public class CreateAccountDto
    {
        //[Required]
        //[StringLength(50, MinimumLength = 3)]
        public string AccountHolderName { get; set; } = string.Empty;
        //[Required]
        //[EmailAddress]
        public string Email { get; set; } = string.Empty;
        //[Required]
        //[Phone]
        public string PhoneNumber { get; set; } = string.Empty;
        //[Range(1000,10000000)]
        public decimal Balance { get; set; }
    }
}
