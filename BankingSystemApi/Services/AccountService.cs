using BankingSystemApi.Data;
using BankingSystemApi.Data.Configurations;
using BankingSystemApi.DTOs;
using BankingSystemApi.Models;
using BankingSystemApi.Services.Interfaces;
using Microsoft.Extensions.Options;

namespace BankingSystemApi.Services
{
    public class AccountService:IAccountService
    {
        private readonly BankingDbContext _dbContext;
        private readonly BankingSettings _settings;
        public AccountService(BankingDbContext dbContext , IOptions<BankingSettings> options)
        {
            _dbContext = dbContext;
            _settings = options.Value;
        }
        //public Guid ServiceId { get; } = Guid.NewGuid();
        public string GetAllAccounts()
        {
            return "All accounts retrieved successfully";
            //return $"ServiceId : {ServiceId}";
        }
        public Account CreateAccount(CreateAccountDto dto)
        {
            if (dto.Balance > _settings.MaxTransactionAmount)
            {
                throw new Exception(
                    $"Maximum allowed amount is {_settings.MaxTransactionAmount}");
            }
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
