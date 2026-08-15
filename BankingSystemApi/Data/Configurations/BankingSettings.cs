namespace BankingSystemApi.Data.Configurations
{
    public class BankingSettings
    {
        public string BankName { get; set; } = string.Empty;

        public string Currency { get; set; } = string.Empty;

        public decimal MaxTransactionAmount { get; set; }
    }
}
