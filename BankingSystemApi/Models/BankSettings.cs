namespace BankingSystemApi.Models
{
    public class BankSettings
    {
        public string BankName { get; set; } = string.Empty;
        public string Branch { get; set; } = string.Empty;
        public string IFSC { get; set; } = string.Empty;
    }
}