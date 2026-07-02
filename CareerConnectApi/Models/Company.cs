namespace CareerConnectApi.Models
{
    public class Company
    {
        public int Id { get; set; }

        public string CompanyName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string PasswordHash { get; set; } = string.Empty;

        public bool IsDeleted { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
