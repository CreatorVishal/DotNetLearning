using BankingSystemApi.Services.Interfaces;

namespace BankingSystemApi.Services
{
    public class SavingAccountService:IAccountTypeService
    {
        public string CreateAccount()
        {
            return "Saving Account Created...";
        }
    }
}
