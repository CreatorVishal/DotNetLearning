using PeopleConnectApi.Models;

namespace PeopleConnectApi.Interface
{
    public interface ITokenService
    {
        Task<string> GenerateTokenAsync (ApplicationUser user);
        Task<string> GenerateRefreshTokenAsync();
    }
}
