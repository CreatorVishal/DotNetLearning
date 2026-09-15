using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PeopleConnectApi.Data;
using PeopleConnectApi.DTOs.Auth;
using PeopleConnectApi.Interface;
using PeopleConnectApi.Models;

namespace PeopleConnectApi.Services
{
    public class AuthService : IAuthService
    {
        private readonly PeopleConnectDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ITokenService _tokenService;
        private readonly IEmailService _emailService;
        private readonly IConfiguration _configuration;

        public AuthService(
            UserManager<ApplicationUser> userManager,
            ITokenService tokenService,
            PeopleConnectDbContext context,
            IEmailService emailService,
            IConfiguration configuration)
        {
            _userManager = userManager;
            _tokenService = tokenService;
            _context = context;
            _emailService = emailService;
            _configuration = configuration;
        }

        public async Task<RegisterResponse> RegisterAsync(
            RegisterRequest request)
        {
            // Step 1: Check if user already exists
            var existingUser =
                await _userManager.FindByEmailAsync(request.Email);

            // Step 2: If user exists, stop registration
            if (existingUser != null)
            {
                throw new InvalidOperationException(
                    "A user with this email already exists.");
            }

            // Step 3: Create ApplicationUser
            var user = new ApplicationUser
            {
                UserName = request.Email,
                Email = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Department = request.Department,
                CreatedAt = DateTime.UtcNow,
                IsActive = true
            };

            // Step 4: Create user through Identity
            var result =
                await _userManager.CreateAsync(
                    user,
                    request.Password);

            // Step 5: Check Identity validation errors
            if (!result.Succeeded)
            {
                var errors = string.Join(
                    ", ",
                    result.Errors.Select(error => error.Description));

                throw new ArgumentException(errors);
            }

            // Step 6: Assign default role
            await _userManager.AddToRoleAsync(
                user,
                "Employee");

            // Step 7: Generate email confirmation token
            var confirmationToken =
                await _userManager.GenerateEmailConfirmationTokenAsync(
                    user);

            // Step 8: Get API base URL from configuration
            var apiBaseUrl =
                _configuration["AppUrls:ApiBaseUrl"];

            if (string.IsNullOrWhiteSpace(apiBaseUrl))
            {
                throw new InvalidOperationException(
                    "API base URL is not configured.");
            }

            // Step 9: Build email confirmation URL
            var confirmationLink =
                $"{apiBaseUrl}/api/Auth/confirm-email" +
                $"?userId={Uri.EscapeDataString(user.Id)}" +
                $"&token={Uri.EscapeDataString(confirmationToken)}";

            // Step 10: Send confirmation email
            await _emailService.SendConfirmationEmailAsync(
                user,
                confirmationLink);

            // Step 11: Return response
            return new RegisterResponse
            {
                Message =
                    "User registered successfully. " +
                    "Please check your email to confirm your account.",

                UserId = user.Id,

                Email = user.Email!
            };
        }

        public async Task<LoginResponse> LoginAsync(
            LoginRequest request)
        {
            // Step 1: Find user by email
            var user =
                await _userManager.FindByEmailAsync(
                    request.Email);

            // Step 2: If user does not exist
            if (user == null)
            {
                throw new UnauthorizedAccessException(
                    "Invalid email or password.");
            }
            if (!user.EmailConfirmed)
            {
                throw new UnauthorizedAccessException(
                    "Please confirm your email before logging in.");
            }

            // Step 3: Check password
            var passwordValid =
                await _userManager.CheckPasswordAsync(
                    user,
                    request.Password);

            // Step 4: If password is incorrect
            if (!passwordValid)
            {
                throw new UnauthorizedAccessException(
                    "Invalid email or password.");
            }

            // Step 5: Generate access token
            var token =
                await _tokenService.GenerateTokenAsync(user);

            // Step 6: Generate refresh token
            var refreshToken =
                await _tokenService.GenerateRefreshTokenAsync();

            // Step 7: Create refresh token entity
            var refreshTokenEntity = new RefreshToken
            {
                Token = refreshToken,
                UserId = user.Id,
                CreatedAt = DateTime.UtcNow,
                ExpiresAt = DateTime.UtcNow.AddDays(7)
            };

            // Step 8: Save refresh token
            _context.RefreshTokens.Add(refreshTokenEntity);

            await _context.SaveChangesAsync();

            // Step 9: Return login response
            return new LoginResponse
            {
                Message = "Login successful.",
                UserId = user.Id,
                Email = user.Email!,
                Token = token,
                RefreshToken = refreshToken
            };
        }

        public async Task<LoginResponse> RefreshAsync(
            string refreshToken)
        {
            // Step 1: Find stored refresh token
            var storedToken =
                await _context.RefreshTokens
                    .FirstOrDefaultAsync(
                        x => x.Token == refreshToken);

            // Step 2: Token not found
            if (storedToken == null)
            {
                throw new UnauthorizedAccessException(
                    "Invalid refresh token.");
            }

            // Step 3: Token expired
            if (storedToken.ExpiresAt <= DateTime.UtcNow)
            {
                throw new UnauthorizedAccessException(
                    "Refresh token has expired.");
            }

            // Step 4: Token revoked
            if (storedToken.RevokedAt != null)
            {
                throw new UnauthorizedAccessException(
                    "Refresh token has been revoked.");
            }

            // Step 5: Find user
            var user =
                await _userManager.FindByIdAsync(
                    storedToken.UserId);

            if (user == null)
            {
                throw new UnauthorizedAccessException(
                    "User not found.");
            }

            // Step 6: Generate new access token
            var newAccessToken =
                await _tokenService.GenerateTokenAsync(user);

            // Step 7: Return response
            return new LoginResponse
            {
                Message = "Token refreshed successfully.",
                UserId = user.Id,
                Email = user.Email!,
                Token = newAccessToken,
                RefreshToken = refreshToken
            };
        }

        public async Task ConfirmEmailAsync(
            string userId,
            string token)
        {
            // Step 1: Find user
            var user =
                await _userManager.FindByIdAsync(userId);

            if (user == null)
            {
                throw new UnauthorizedAccessException(
                    "Invalid email confirmation request.");
            }

            // Step 2: Confirm email through ASP.NET Core Identity
            var result =
                await _userManager.ConfirmEmailAsync(
                    user,
                    token);

            // Step 3: Check confirmation result
            if (!result.Succeeded)
            {
                var errors = string.Join(
                    ", ",
                    result.Errors.Select(
                        error => error.Description));

                throw new UnauthorizedAccessException(errors);
            }
        }
    }
}