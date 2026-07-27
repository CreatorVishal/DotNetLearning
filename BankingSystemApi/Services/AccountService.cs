using BankingSystemApi.Data;
using BankingSystemApi.DTOs;
using BankingSystemApi.Models;
using BankingSystemApi.Services.Interfaces;

namespace BankingSystemApi.Services
{
    public class AccountService:IAccountService
    {
        private readonly BankingDbContext _dbContext;
        public AccountService(BankingDbContext dbContext)
        {
            _dbContext = dbContext;

        }
        //public Guid ServiceId { get; } = Guid.NewGuid();
        public string GetAllAccounts()
        {
            return "All accounts retrieved successfully";
            //return $"ServiceId : {ServiceId}";
        }
        public Account CreateAccount(CreateAccountDto dto)
        {
            var account = new Account();
            account.AccountHolderName = dto.AccountHolderName;
            account.Email = dto.Email;
            account.PhoneNumber = dto.PhoneNumber;
            account.Balance = dto.Balance;
            account.CreatedAt = DateTime.Now;
            account.IsActive = true;
            account.AccountNumber = Guid.NewGuid().ToString()[..10];
            _dbContext.Accounts.Add(account);
            _dbContext.SaveChanges();
            return account;

        }
    }
}
