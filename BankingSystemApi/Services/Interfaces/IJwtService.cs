using BankingSystemApi.Models;
namespace BankingSystemApi.Services.Interfaces
{
    public interface IJwtService
    {
        string GenerateToken(User user);
    }
}
