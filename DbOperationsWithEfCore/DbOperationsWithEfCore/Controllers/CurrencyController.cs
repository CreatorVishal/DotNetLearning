using DbOperationsWithEfCore.Data;
using Microsoft.AspNetCore.Mvc;

namespace DbOperationsWithEfCore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CurrencyController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CurrencyController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetCurrencies()
        {
            var data = _context.Currencies.ToList();

            return Ok(data);
        }
    }
}