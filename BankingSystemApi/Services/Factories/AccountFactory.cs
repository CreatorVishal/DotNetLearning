using BankingSystemApi.Services.Interfaces;
using BankingSystemApi.Services;
using Microsoft.Extensions.DependencyInjection;

namespace BankingSystemApi.Services.Factories
{
    public class AccountFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public AccountFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public IAccountTypeService GetAccountService(string accountType)
        {
            return accountType switch
            {
                "Savings" => _serviceProvider.GetRequiredService<SavingAccountService>(),

                "Current" => _serviceProvider.GetRequiredService<CurrentAccountService>(),

                "Salary" => _serviceProvider.GetRequiredService<SalaryAccountService>(),

                _ => throw new Exception("Invalid Account Type")
            };
        }
    }
}