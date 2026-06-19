using GymManagementApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace GymManagementApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MemberController : ControllerBase
{
    [HttpGet]
    public Member Get()
    {
        return new Member
        {
            Id = 1,
            Name = "Vishal",
            Age = 22
        };
    }
    [HttpGet("{id}")]
    public string GetById(int id)
    {
        return $"Member Id = {id}";
    }
}