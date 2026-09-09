using Microsoft.AspNetCore.Mvc;
using PeopleConnectApi.DTOs.Auth;
using PeopleConnectApi.Interface;

namespace PeopleConnectApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]   
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        [HttpPost("register")]
        public async Task<ActionResult<RegisterResponse>> Register(RegisterRequest request)
        {
            var response = await _authService.RegisterAsync(request);
            return Ok(response);

        }
        [HttpPost("login")]
        public async Task<ActionResult<LoginResponse>> Login(
    LoginRequest request)
        {
            var response = await _authService.LoginAsync(request);

            return Ok(response);
        }
        [HttpPost("refresh")]
        public async Task<ActionResult<LoginResponse>> Refresh(string refreshToken)
        {
            var response = await _authService.RefreshAsync(refreshToken);

            return Ok(response);
        }

    }
}
