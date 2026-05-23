using DbOperationsWithEfCore.Services;
using Microsoft.AspNetCore.Mvc;

namespace DbOperationsWithEfCore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CurrencyController : ControllerBase
    {
        private readonly ICurrencyService _currencyService;

        // DI Here
        public CurrencyController(ICurrencyService currencyService)
        {
            _currencyService = currencyService;
        }

        [HttpGet]
        public IActionResult GetCurrencies()
        {
            var data = _currencyService.GetAllCurrencies();

            return Ok(data);
        }

        [HttpGet("{id}")]
        public IActionResult GetCurrencyById(int id)
        {
            var currency = _currencyService.GetCurrencyById(id);

            if (currency == null)
            {
                return NotFound("Currency not found");
            }

            return Ok(currency);
        }

        [HttpGet("count")]
        public IActionResult GetCurrencyCount()
        {
            var count = _currencyService.GetCurrencyCount();

            return Ok(count);
        }
    }
}