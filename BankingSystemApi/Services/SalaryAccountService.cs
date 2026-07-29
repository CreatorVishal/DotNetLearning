using BankingSystemApi.Services.Interfaces;

namespace BankingSystemApi.Services
{
    public class SalaryAccountService : IAccountTypeService
    {
        public string CreateAccount()
        {
            return "Salary Account Created";
        }
    }
}