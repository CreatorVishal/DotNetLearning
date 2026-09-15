using PeopleConnectApi.Interface;
using PeopleConnectApi.Models;
using PeopleConnectApi.Models.Email;

namespace PeopleConnectApi.Services
{
    public class EmailService : IEmailService
    {
        private readonly IEmailTemplateService _templateService;
        private readonly IEmailSender _emailSender;

        public EmailService(
            IEmailTemplateService templateService,
            IEmailSender emailSender)
        {
            _templateService = templateService;
            _emailSender = emailSender;
        }

        public async Task SendConfirmationEmailAsync(
            ApplicationUser user,
            string confirmationLink)
        {
            if (string.IsNullOrWhiteSpace(user.Email))
            {
                throw new InvalidOperationException(
                    "User email is required.");
            }

            var model = new EmailConfirmationModel
            {
                FirstName = user.FirstName,
                ConfirmationLink = confirmationLink
            };

            var htmlBody =
                await _templateService.RenderTemplateAsync(
                    "EmailConfirmation",
                    model);

            var message = new EmailMessage
            {
                To = user.Email,
                Subject = "Verify your PeopleConnect account",
                HtmlBody = htmlBody
            };

            await _emailSender.SendAsync(message);
        }
    }
}

        //public async Task SendEmailAsync(
        //    string to,
        //    string subject,
        //    string body)
        //{
        //    using var message = new MailMessage();

        //    message.From = new MailAddress(
        //        _emailSettings.SenderEmail,
        //        _emailSettings.SenderName);

        //    message.To.Add(to);
        //    message.Subject = subject;
        //    message.Body = body;
        //    message.IsBodyHtml = true;

        //    using var smtpClient = new SmtpClient(
        //        _emailSettings.SmtpServer,
        //        _emailSettings.Port);

        //    smtpClient.EnableSsl = true;

        //    smtpClient.Credentials = new NetworkCredential(
        //        _emailSettings.Username,
        //        _emailSettings.Password);

        //    await smtpClient.SendMailAsync(message);
        //}
