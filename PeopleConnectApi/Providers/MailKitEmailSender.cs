using Microsoft.Extensions.Options;
using PeopleConnectApi.Interface;
using PeopleConnectApi.Models;
using PeopleConnectApi.Models.Email;
using MimeKit;
using MailKit.Security;
using MailKit.Net.Smtp;


namespace PeopleConnectApi.Providers
{
    public class MailKitEmailSender:IEmailSender

    {
        private readonly EmailSettings _settings;
        public MailKitEmailSender(IOptions<EmailSettings> options)
        {
            _settings = options.Value;
        }
        public async Task SendAsync(EmailMessage message)
        {
            var email = new MimeMessage();
            email.From.Add(new MailboxAddress(_settings.SenderName, _settings.SenderEmail));
            email.To.Add(MailboxAddress.Parse(message.To));
            email.Subject = message.Subject;
            email.Body = new BodyBuilder
            {
                HtmlBody = message.HtmlBody
            }.ToMessageBody();
            using var smtpClient = new SmtpClient();
            await smtpClient.ConnectAsync(_settings.SmtpServer, _settings.Port, SecureSocketOptions.StartTls);
            await smtpClient.AuthenticateAsync(
                _settings.Username,
                _settings.Password);
            await smtpClient.SendAsync(email);
            await smtpClient.DisconnectAsync(true);

        } 
    }
}
