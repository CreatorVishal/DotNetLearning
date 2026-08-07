using BankingSystemApi.DTOs.Auth;
using BankingSystemApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BankingSystemApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _service;
        public AuthController(IUserService service)
        {
            _service = service;
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterUserDto dto)
        {
            await _service.RegisterAsync(dto);

            return Ok("User Registered Successfully");
        }
    }
}
