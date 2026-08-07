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
        public UserService(BankingDbContext context, IPasswordHasher<User> passwordHasher)
        {
            _context = context;
            _passwordHasher = passwordHasher;
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
    }
}
