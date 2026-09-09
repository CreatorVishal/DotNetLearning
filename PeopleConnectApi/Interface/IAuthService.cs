using PeopleConnectApi.DTOs.Auth;

namespace PeopleConnectApi.Interface
{
    public interface IAuthService
    {
        Task<RegisterResponse> RegisterAsync(RegisterRequest request);
        Task<LoginResponse> LoginAsync(LoginRequest request);
        Task<LoginResponse> RefreshAsync(string refreshToken);
    }
}