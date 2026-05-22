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
        [HttpGet("{id}")]
        public IActionResult GetCurrencyById(int id)
        {
            var currency = _context.Currencies.FirstOrDefault(x => x.Id == id);

            if (currency == null)
            {
                return NotFound("Currency not found");
            }

            return Ok(currency);
        }
    }
}