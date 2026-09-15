using PeopleConnectApi.Models.Email;

namespace PeopleConnectApi.Interface
{
    public interface IEmailSender
    {
        Task SendAsync(EmailMessage message);
    }
}