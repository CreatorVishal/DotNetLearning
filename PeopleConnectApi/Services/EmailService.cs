using System.Net;
using System.Net.Mail;
using Microsoft.Extensions.Options;
using PeopleConnectApi.Interface;
using PeopleConnectApi.Models;

namespace PeopleConnectApi.Services
{
    public class EmailService : IEmailService
    {
        private readonly EmailSettings _emailSettings;

        public EmailService(IOptions<EmailSettings> emailSettings)
        {
            _emailSettings = emailSettings.Value;
        }

        public async Task SendEmailAsync(
            string to,
            string subject,
            string body)
        {
            using var message = new MailMessage();

            message.From = new MailAddress(
                _emailSettings.SenderEmail,
                _emailSettings.SenderName);

            message.To.Add(to);
            message.Subject = subject;
            message.Body = body;
            message.IsBodyHtml = true;

            using var smtpClient = new SmtpClient(
                _emailSettings.SmtpServer,
                _emailSettings.Port);

            smtpClient.EnableSsl = true;

            smtpClient.Credentials = new NetworkCredential(
                _emailSettings.Username,
                _emailSettings.Password);

            await smtpClient.SendMailAsync(message);
        }
    }
}