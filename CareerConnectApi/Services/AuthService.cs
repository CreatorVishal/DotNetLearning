using Microsoft.EntityFrameworkCore;
using CareerConnectApi.Data;
using CareerConnectApi.DTOs;
using CareerConnectApi.Interfaces;

namespace CareerConnectApi.Services;

public class AuthService : IAuthService
{
    private readonly AppDbContextAuth _context;

    public AuthService(AppDbContextAuth context)
    {
        _context = context;
    }
    public async Task RegisterAsync(RegisterRequestDto request)
    {

        var userExists = await _context.UserAccounts.AnyAsync(x => x.Email == request.Email);
        if (userExists)
        {
            throw new Exception("Email already exists.");
        }
    }

    public async Task<AuthResponseDto> LoginAsync(LoginRequestDto request)
    {
        throw new NotImplementedException();
    }
}