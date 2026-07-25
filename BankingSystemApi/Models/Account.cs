

namespace BankingSystemApi.Models
{
    public class Account
    {
        public int Id { get; set; }
        public string AccountNumber { get; set; }= string.Empty;
        public string AccountHolderName { get; set; } = string.Empty;
        public decimal Balance { get; set; }
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; }= string.Empty;
        public DateTime CreatedAt { get; set; }
        public Boolean IsActive { get; set; }
    }
}
