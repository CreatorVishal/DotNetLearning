using BankingSystemApi.Services.Interfaces;

namespace BankingSystemApi.Services
{
    public class CurrentAccountService:IAccountTypeService
    {
        public string CreateAccount()
        {
            return "Current Account Created...";
        }
    
    }
}
