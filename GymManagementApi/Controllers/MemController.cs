using GymManagementApi.Data;
using GymManagementApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GymManagementApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MemController : ControllerBase
    {
        private readonly AppDbContext _Context;
        public MemController(AppDbContext Context)
        {
            _Context = Context;
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var res = await _Context.Members.FindAsync(id);
            if (res is not null)
            {
                return Ok(res);
            }
            return NotFound("gnd");

        }
        [HttpGet("/FindAll")]
        public async Task<IActionResult> GettData()
        {
            var res = await _Context.Members.ToListAsync();
            if (res.Count > 0)
            {
                return Ok(res);
            }
            return BadRequest(new
            {
                Message = "Welcome"
            });

        }


    }
}
