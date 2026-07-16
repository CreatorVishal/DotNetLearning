using CareerConnectApi.DTOs;

namespace CareerConnectApi.Interfaces;

public interface IEmployeeService
{
    Task RegisterAsync(RegisterEmployeeDto dto);

    Task<string?> LoginAsync(LoginEmployeeDto dto);
}