using CareerConnectApi.DTOs;
using CareerConnectApi.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CareerConnectApi.Controllers;

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
    public async Task<IActionResult> Register(RegisterRequestDto request)
    {
        await _authService.RegisterAsync(request);

        return Ok("User Registered Successfully");
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequestDto request)
    {
        var result = await _authService.LoginAsync(request);

        return Ok(result);
    }
}