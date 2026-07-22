using CareerConnectApi.DTOs;

namespace CareerConnectApi.Interfaces;

public interface IAuthService
{
    Task RegisterAsync(RegisterRequestDto request);

    Task<AuthResponseDto> LoginAsync(LoginRequestDto request);
}


