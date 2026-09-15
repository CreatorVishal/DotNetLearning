using PeopleConnectApi.Models;

namespace PeopleConnectApi.Interface
{
    public interface IEmailService
    {
        Task SendConfirmationEmailAsync(ApplicationUser user, string confirmationLink);
    }
}
