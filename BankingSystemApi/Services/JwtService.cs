using BankingSystemApi.Services.Interfaces;
using BankingSystemApi.Models;
using System.Security.Cryptography;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
namespace BankingSystemApi.Services
{
    public class JwtService:IJwtService
    {
        private readonly IConfiguration _configuration;

        public JwtService(IConfiguration configuration) { 
            _configuration = configuration;
        }
        public string GenerateToken(User user)
        {
            var key = _configuration["Jwt:Key"];
            var issuer = _configuration["Jwt:Issuer"];
            var audience = _configuration["Jwt:Audience"];
            var duration = _configuration.GetValue<int>("Jwt:DurationInMinutes");

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
                new Claim(ClaimTypes.Name,user.Name),
                new Claim(ClaimTypes.Email,user.Email),
                new Claim(ClaimTypes.Role,user.Role),
                new Claim("Permission","CanManageAccounts")
            };


            //step 3
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key!));

            //Step 4
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: issuer,
                 audience: audience,
                 claims: claims,
                 expires: DateTime.UtcNow.AddMinutes(duration),
                 signingCredentials: credentials
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        public string GenerateRefreshToken()
        {
            var randomBytes= new byte[32];
           using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomBytes);
            return Convert.ToBase64String(randomBytes);
        }
    }
}
