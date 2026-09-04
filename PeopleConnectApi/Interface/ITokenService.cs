using PeopleConnectApi.Models;

namespace PeopleConnectApi.Interface
{
    public interface ITokenService
    {
        string GenerateToken(ApplicationUser user);
    }
}
