using GymManagementApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace GymManagementApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MemberController : ControllerBase
{
    private static List<Member> members = new()
    {
        new Member
        {
            Id = 1,
            Name = "Vishal",
            Age = 23,
            MembershipType = "Gold",
        },

        new Member
        {
            Id = 2,
            Name = "Rahul",
            Age = 25,
            MembershipType = "Silver"
        }
    };

    [HttpGet]
    public List<Member> GetMembers()
    {
        return members;
    }
    [HttpGet("{id}")]
    public IActionResult GetMemberById(int id)
    {
        var member = members.FirstOrDefault(m => m.Id == id);

        if (member == null)
        {
            return NotFound();
        }

        return Ok(member);
    }
    [HttpPost]
     public IActionResult AddMember(Member member)
    {
        members.Add(member);
        return Ok(member);
    }

}