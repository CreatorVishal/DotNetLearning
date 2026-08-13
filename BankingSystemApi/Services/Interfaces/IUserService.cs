using BankingSystemApi.DTOs.Auth;

namespace BankingSystemApi.Services.Interfaces
{
    public interface IUserService
    {
        Task RegisterAsync(RegisterUserDto dto);

        Task<LoginResponseDto?> LoginAsync(LoginUserDto dto);

        Task<LoginResponseDto?> RefreshTokenAsync(RefreshTokenDto dto);
    }
}