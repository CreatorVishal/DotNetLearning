using Microsoft.AspNetCore.Mvc;
using PeopleConnectApi.DTOs.Email;
using PeopleConnectApi.Interface;
using PeopleConnectApi.Models;

namespace PeopleConnectApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmailController : ControllerBase
    {
        private readonly IEmailService _emailService;
        private readonly IEmailTemplateService _emailTemplateService;

        public EmailController(
            IEmailService emailService,
            IEmailTemplateService emailTemplateService)
        {
            _emailService = emailService;
            _emailTemplateService = emailTemplateService;
        }
        

        [HttpPost("send")]
        public async Task<IActionResult> SendEmail(
            SendEmailRequest request)
        {
            await _emailService.SendEmailAsync(
                request.To,
                request.Subject,
                request.Body);

            return Ok("Email sent successfully.");
        }
        [HttpGet("test-template")]
        public async Task<IActionResult> TestTemplate()
        {
            var model = new EmailConfirmationModel
            {
                FirstName = "Vishal",
                ConfirmationLink = "https://example.com/confirm-email"
            };

            var html = await _emailTemplateService.RenderTemplateAsync(
                "EmailConfirmation",
                model);

            return Content(html, "text/html");
        }
    }
}