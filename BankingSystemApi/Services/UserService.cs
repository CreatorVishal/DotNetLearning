using BankingSystemApi.Data;
using BankingSystemApi.DTOs.Auth;
using BankingSystemApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using BankingSystemApi.Services.Interfaces;

namespace BankingSystemApi.Services
{
    public class UserService : IUserService
    {
        private readonly BankingDbContext _context;
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly IJwtService _jwtService;
        public UserService(BankingDbContext context, IPasswordHasher<User> passwordHasher, IJwtService jwtService)
        {
            _context = context;
            _passwordHasher = passwordHasher;
            _jwtService = jwtService;
        }
        public async Task RegisterAsync(RegisterUserDto dto)
        {
            // Step 1: Check if email already exists
            bool emailExists = await _context.Users
                .AnyAsync(x => x.Email == dto.Email);
            if (emailExists)
            {
                throw new Exception("Email already exists.");
            }



            // Step 2: Create User Entity
            var user = new User();

            // Step 3: Hash Password
            string hashedPassword = _passwordHasher.HashPassword(user, dto.Password);

            // Step 4: Assign Values
            user.Name = dto.Name;
            user.Email = dto.Email;
            user.PasswordHash = hashedPassword;
            user.Role = "Customer";
            user.IsActive = true;
            user.CreatedAt = DateTime.UtcNow;

            // Step 5: Add User
            _context.Users.Add(user);

            // Step 6: Save User
            await _context.SaveChangesAsync();


        }
        //Login async
        public async Task<LoginResponseDto?> LoginAsync(LoginUserDto dto)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x=>x.Email==dto.Email);

            if (user == null)
            {
                return null;
            }
            var passwordResult= _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, dto.Password);
            if (passwordResult ==PasswordVerificationResult.Failed)
            {
                return null;
            }
            var accessToken = _jwtService.GenerateToken(user);
            
            var RefreshToken = _jwtService.GenerateRefreshToken();
            var refreshTokenEntity = new RefreshToken
            {
                Token = RefreshToken,
                UserId = user.Id,
                ExpireAt = DateTime.UtcNow.AddDays(7),
                CreatedAt = DateTime.UtcNow
            };
            _context.RefreshTokens.Add(refreshTokenEntity);
            await _context.SaveChangesAsync();

            return new LoginResponseDto
            {
                AccessToken = accessToken,
                RefreshToken = RefreshToken,
            };
        }

        // REFRESH TOKEN
        // =========================
        public async Task<LoginResponseDto?> RefreshTokenAsync(
            RefreshTokenDto dto)
        {
            // 1. Find refresh token in database
            var refreshToken = await _context.RefreshTokens
                .FirstOrDefaultAsync(x => x.Token == dto.RefreshToken);

            // 2. Token does not exist
            if (refreshToken == null)
            {
                return null;
            }

            // 3. Check expiry
            if (refreshToken.ExpireAt <= DateTime.UtcNow)
            {
                return null;
            }

            // 4. Check if token was revoked
            if (refreshToken.RevokedAt != null)
            {
                return null;
            }

            // 5. Find related user
            var user = await _context.Users
                .FirstOrDefaultAsync(x => x.Id == refreshToken.UserId);

            if (user == null)
            {
                return null;
            }

            // 6. Generate new Access Token
            var newAccessToken = _jwtService.GenerateToken(user);

            // 7. Generate new Refresh Token
            var newRefreshToken = _jwtService.GenerateRefreshToken();

            // 8. Revoke old refresh token
            refreshToken.RevokedAt = DateTime.UtcNow;

            // 9. Create new RefreshToken entity
            var newRefreshTokenEntity = new RefreshToken
            {
                Token = newRefreshToken,
                UserId = user.Id,
                ExpireAt = DateTime.UtcNow.AddDays(7),
                CreatedAt = DateTime.UtcNow
            };

            // 10. Save new refresh token
            _context.RefreshTokens.Add(newRefreshTokenEntity);

            await _context.SaveChangesAsync();

            // 11. Return new tokens
            return new LoginResponseDto
            {
                AccessToken = newAccessToken,
                RefreshToken = newRefreshToken
            };
        }
    }
}
