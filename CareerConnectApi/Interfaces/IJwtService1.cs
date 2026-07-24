using CareerConnectApi.Models;

namespace CareerConnectApi.Interfaces;

public interface IJwtService1
{
    string GenerateToken(UserAccount user);
    string GenerateRefreshToken();
}