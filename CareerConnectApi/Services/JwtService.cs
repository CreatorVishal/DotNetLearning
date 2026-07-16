using CareerConnectApi.Interfaces;
using CareerConnectApi.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CareerConnectApi.Services;

public class JwtService : IJwtService
{
    private readonly IConfiguration _configuration;

    public JwtService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string GenerateToken(Employee employee)
    {
        // Secret Key
        var key = _configuration["Jwt:Key"]!;

        var securityKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(key));

        // Signing Credentials
        var credentials = new SigningCredentials(
            securityKey,
            SecurityAlgorithms.HmacSha256);

        // Claims
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, employee.Id.ToString()),
            new Claim(ClaimTypes.Name, employee.Name),
            new Claim(ClaimTypes.Email, employee.Email)
        };

        // JWT Token
        var token = new JwtSecurityToken(
            issuer: _configuration["Jwt:Issuer"],
            audience: _configuration["Jwt:Audience"],
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(
                Convert.ToDouble(_configuration["Jwt:ExpiryInMinutes"])),
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}