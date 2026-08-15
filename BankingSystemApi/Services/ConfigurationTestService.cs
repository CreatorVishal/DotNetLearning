namespace BankingSystemApi.Services
{
    public class ConfigurationTestService
    {
        private readonly IConfiguration _configuration;
        public ConfigurationTestService(IConfiguration configuration)
        {
            _configuration = configuration;

        }
        public void Test()
        {
            var bankName = _configuration["Banking:BankName"];
            var currency = _configuration["Banking:Currency"];
            var maxAmount =_configuration["Banking:MaxTransactionAmount"];

            Console.WriteLine(bankName);
            Console.WriteLine(currency);
            Console.WriteLine(maxAmount);
        }
    }
}
