using Microsoft.AspNetCore.Identity;
using PeopleConnectApi.DTOs.Auth;
using PeopleConnectApi.Interface;
using PeopleConnectApi.Models;
using PeopleConnectApi.Data;
using Microsoft.EntityFrameworkCore;

namespace PeopleConnectApi.Services
{
    public class AuthService : IAuthService

    {
        private readonly PeopleConnectDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ITokenService _tokenService;
        public AuthService(UserManager<ApplicationUser> userManager,ITokenService tokenService, PeopleConnectDbContext context)
        {
            _userManager = userManager;
            _tokenService = tokenService;
            _context = context;
        }
        public async Task<RegisterResponse> RegisterAsync(RegisterRequest request)
        {
            //Step 1 Check if user already exist
            var existingUser = await _userManager.FindByEmailAsync(request.Email);
            //Step2 if exists then throw Exception
            if (existingUser != null)
            {
                throw new InvalidOperationException("A user with this email already exists.");
            }
            //Otherwise 
            var user = new ApplicationUser
            {
                UserName = request.Email,
                Email=request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Department=request.Department,
                CreatedAt = DateTime.UtcNow,
                IsActive = true
            };
            var result= await _userManager.CreateAsync(user,request.Password);
            if (!result.Succeeded)
            {
                var errors = string.Join(
                    ", ",
                    result.Errors.Select(error => error.Description));
                

                throw new ArgumentException(errors);
            }
            await _userManager.AddToRoleAsync(user, "Employee");
            return new RegisterResponse
            {
                Message = "User registered successfully.",
                UserId = user.Id,
                Email = user.Email!
            };
           

        }
        public async Task<LoginResponse> LoginAsync(LoginRequest request)
        {
            // Step 1: Find user by email
            var user = await _userManager.FindByEmailAsync(request.Email);
            // Step 2: If user does not exist
            if (user == null)
            {
                throw new UnauthorizedAccessException("Invalid email or password.");
            }
            // Step 3: Check password
            var passwordValid = await  _userManager.CheckPasswordAsync(user, request.Password);
            // Step 4: If password is incorrect
            if (!passwordValid)
            {
                throw new UnauthorizedAccessException(
                    "Invalid email or password.");
            }
            var token = await _tokenService.GenerateTokenAsync(user);

            var refreshToken = await _tokenService.GenerateRefreshTokenAsync();

            var refreshTokenEntity = new RefreshToken
            {
                Token = refreshToken,
                UserId = user.Id,
                CreatedAt = DateTime.UtcNow,
                ExpiresAt = DateTime.UtcNow.AddDays(7)
            };

            _context.RefreshTokens.Add(refreshTokenEntity);

            await _context.SaveChangesAsync();

            return new LoginResponse
            {
                Message = "Login successful.",
                UserId = user.Id,
                Email = user.Email!,
                Token = token,
                RefreshToken = refreshToken
            };

        }
        public async Task<LoginResponse> RefreshAsync(string refreshToken)
        {
            var storedToken = await _context.RefreshTokens
                .FirstOrDefaultAsync(x => x.Token == refreshToken);

            if (storedToken == null)
            {
                throw new UnauthorizedAccessException("Invalid refresh token.");
            }

            if (storedToken.ExpiresAt <= DateTime.UtcNow)
            {
                throw new UnauthorizedAccessException("Refresh token has expired.");
            }

            if (storedToken.RevokedAt != null)
            {
                throw new UnauthorizedAccessException("Refresh token has been revoked.");
            }

            var user = await _userManager.FindByIdAsync(storedToken.UserId);

            if (user == null)
            {
                throw new UnauthorizedAccessException("User not found.");
            }

            var newAccessToken = await _tokenService.GenerateTokenAsync(user);

            return new LoginResponse
            {
                Message = "Token refreshed successfully.",
                UserId = user.Id,
                Email = user.Email!,
                Token = newAccessToken,
                RefreshToken = refreshToken
            };
        }
    }
}
