using CareerConnectApi.Models;

namespace CareerConnectApi.Interfaces;

public interface IJwtService
{
    string GenerateToken(Employee employee);
}