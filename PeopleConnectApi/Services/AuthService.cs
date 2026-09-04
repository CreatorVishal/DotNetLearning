using Microsoft.AspNetCore.Identity;
using PeopleConnectApi.DTOs.Auth;
using PeopleConnectApi.Interface;
using PeopleConnectApi.Models;

namespace PeopleConnectApi.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ITokenService _tokenService;
        public AuthService(UserManager<ApplicationUser> userManager,ITokenService tokenService)
        {
            _userManager = userManager;
            _tokenService = tokenService;
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
            var token = _tokenService.GenerateToken(user);
            return new LoginResponse
            {
                Message = "Login successful.",
                UserId = user.Id,
                Email = user.Email!,
                Token=token
            };

        } 
    }
}
