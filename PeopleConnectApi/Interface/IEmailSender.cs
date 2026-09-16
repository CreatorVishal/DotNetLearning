using PeopleConnectApi.Models.Email;

namespace PeopleConnectApi.Interface
{
   public interface IEmailSender
    {
        public Task SendAsync(EmailMessage message);
    }
}