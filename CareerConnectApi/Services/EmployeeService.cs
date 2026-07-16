using CareerConnectApi.Data;
using CareerConnectApi.DTOs;
using CareerConnectApi.Interfaces;
using CareerConnectApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
namespace CareerConnectApi.Services;

public class EmployeeService : IEmployeeService
{
    private readonly AppDbContextAuth _context;
    private readonly PasswordHasher<Employee> _passwordHasher;
    private readonly IJwtService _jwtService;

    public EmployeeService(AppDbContextAuth context,IJwtService jwtService)
    {
        _context = context;
        _jwtService = jwtService;
        _passwordHasher = new PasswordHasher<Employee>();
    }


    //public async Task RegisterAsync(RegisterEmployeeDto dto)
    //{
    //    var employee = new Employee
    //    {
    //        Name = dto.Name,
    //        Email = dto.Email,
    //        PasswordHash = dto.Password
    //    };

    //    _context.Employees.Add(employee);

    //    await _context.SaveChangesAsync();
    //}
    public async Task RegisterAsync(RegisterEmployeeDto dto)
    {
        var isEmailExist = await _context.Employees
            .AnyAsync(x => x.Email == dto.Email);

        if (isEmailExist)
        {
            throw new Exception("Email already exists.");
        }

        var employee = new Employee
        {
            Name = dto.Name,
            Email = dto.Email
        };

        employee.PasswordHash = _passwordHasher.HashPassword(employee, dto.Password);

        _context.Employees.Add(employee);

        await _context.SaveChangesAsync();
    }

    public async Task<string?> LoginAsync(LoginEmployeeDto dto)
    {
        var employee = await _context.Employees
            .FirstOrDefaultAsync(x => x.Email == dto.Email);

        if (employee == null)
        {
            return null;
        }

        var result = _passwordHasher.VerifyHashedPassword(
            employee,
            employee.PasswordHash,
            dto.Password);

        if (result == PasswordVerificationResult.Failed)
        {
            return null;
        }

        var token = _jwtService.GenerateToken(employee);

        return token;
    }
}