using BankingSystemApi.DTOs;
using BankingSystemApi.Models;


namespace BankingSystemApi.Services.Interfaces
{
    public interface IAccountService
    {
        //public string GetWelcomeMessage();
        //Guid ServiceId { get; }
        public string GetAllAccounts();
        public Account CreateAccount(CreateAccountDto dto);
    }
}
