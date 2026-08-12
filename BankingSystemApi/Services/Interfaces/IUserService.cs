using BankingSystemApi.DTOs.Auth;

namespace BankingSystemApi.Services.Interfaces
{
    public interface IUserService
    {
        Task RegisterAsync(RegisterUserDto dto);
        Task<string?> LoginAsync(LoginUserDto dto);
    }
}
