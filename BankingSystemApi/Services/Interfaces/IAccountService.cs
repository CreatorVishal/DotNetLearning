namespace BankingSystemApi.Services.Interfaces
{
    public interface IAccountService
    {
        //public string GetWelcomeMessage();
        Guid ServiceId { get; }
        public string GetAllAccounts();
    }
}
