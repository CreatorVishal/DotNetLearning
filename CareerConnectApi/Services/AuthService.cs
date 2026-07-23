using CareerConnectApi.Data;
using CareerConnectApi.DTOs;
using CareerConnectApi.Interfaces;
using CareerConnectApi.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CareerConnectApi.Services;

public class AuthService : IAuthService
{
    private readonly AppDbContextAuth _context;
    private readonly IJwtService1 _jwtService;
    private readonly PasswordHasher<UserAccount> _passwordHasher = new();
    private readonly IConfiguration _configuration;

    public AuthService(AppDbContextAuth context,IJwtService1 jwtService,IConfiguration configuration)
    {
        _context = context;
        _jwtService = jwtService;
        _configuration = configuration;
    }
    public async Task RegisterAsync(RegisterRequestDto request)
    {

        var userExists = await _context.UserAccounts.AnyAsync(x => x.Email == request.Email);
        if (userExists)
        {
            throw new Exception("Email already exists.");
        }
        var user = new UserAccount
        {
            FullName = request.FullName,
            Email = request.Email,
            //PasswordHash = request.Password, // Temporary
           
            Role = "Employee",
            IsActive = true,
            CreatedAt = DateTime.UtcNow
        };
        user.PasswordHash = _passwordHasher.HashPassword(user, request.Password);

        _context.UserAccounts.Add(user);

        await _context.SaveChangesAsync();
    }

    public async Task<AuthResponseDto> LoginAsync(LoginRequestDto request)
    {
        var user = await _context.UserAccounts.FirstOrDefaultAsync(x => x.Email == request.Email);
        if (user == null)
        {
            throw new Exception("Invalid email "); 
        }
        var result = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, request.Password);
        if (result == PasswordVerificationResult.Failed)
        {
            throw new Exception("Invalid password.");
        }
        var token = _jwtService.GenerateToken(user);
        return new AuthResponseDto
        {
            Token = token,
            Expiration = DateTime.UtcNow.AddMinutes(Convert.ToDouble(_configuration["Jwt:ExpiryInMinutes"]))
        };
    }
}