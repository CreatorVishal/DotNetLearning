using Microsoft.Extensions.Options;
using PeopleConnectApi.Interface;
using PeopleConnectApi.Models;
using PeopleConnectApi.Models.Email;
using System.Net;
using System.Net.Mail;

namespace PeopleConnectApi.Providers
{
    public class SmtpEmailSender : IEmailSender
    {
        private readonly EmailSettings _settings;

        public SmtpEmailSender(IOptions<EmailSettings> options)
        {
            _settings = options.Value;
        }

        public async Task SendAsync(EmailMessage message)
        {
            if (string.IsNullOrWhiteSpace(message.To))
            {
                throw new ArgumentException(
                    "Recipient email address is required.");
            }

            if (string.IsNullOrWhiteSpace(message.Subject))
            {
                throw new ArgumentException(
                    "Email subject is required.");
            }

            if (string.IsNullOrWhiteSpace(message.HtmlBody))
            {
                throw new ArgumentException(
                    "Email body is required.");
            }

            using var mailMessage = new MailMessage();

            mailMessage.From = new MailAddress(
                _settings.SenderEmail,
                _settings.SenderName);

            mailMessage.To.Add(message.To);

            mailMessage.Subject = message.Subject;

            mailMessage.Body = message.HtmlBody;

            mailMessage.IsBodyHtml = true;

            using var smtpClient = new SmtpClient(
                _settings.SmtpServer,
                _settings.Port);

            smtpClient.EnableSsl = true;

            smtpClient.Credentials = new NetworkCredential(
                _settings.Username,
                _settings.Password);

            await smtpClient.SendMailAsync(mailMessage);
        }
    }
}