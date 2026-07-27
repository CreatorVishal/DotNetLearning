using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace BankingSystemApi.DTOs
{
    public class CustomerRegistrationDto
    {
        [Required]
        public string FullName { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        public IFormFile AadhaarPhoto { get; set; } = default!;
    }
}