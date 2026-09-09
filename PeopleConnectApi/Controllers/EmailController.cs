using Microsoft.AspNetCore.Mvc;
using PeopleConnectApi.DTOs.Email;
using PeopleConnectApi.Interface;

namespace PeopleConnectApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmailController : ControllerBase
    {
        private readonly IEmailService _emailService;

        public EmailController(IEmailService emailService)
        {
            _emailService = emailService;
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
    }
}