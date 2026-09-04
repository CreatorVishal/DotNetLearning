using PeopleConnectApi.DTOs.Auth;

namespace PeopleConnectApi.Interface
{
    public interface IAuthService
    {
        public Task<RegisterResponse> RegisterAsync(RegisterRequest request);
        public Task<LoginResponse> LoginAsync(LoginRequest request);
    }
}
