using BankingSystemApi.Services.Interfaces;

namespace BankingSystemApi.Services
{
    public class AccountService:IAccountService
    {
        public Guid ServiceId { get; } = Guid.NewGuid();
        public string GetAllAccounts()
        {
            //return "All accounts retrieved successfully";
            return $"ServiceId : {ServiceId}";
        }
    }
}
