using BankingSystemApi.DTOs;
using BankingSystemApi.Models;
using BankingSystemApi.Services.Factories;
using BankingSystemApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
namespace BankingSystemApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    // Step 1 : Receive Request

    // Step 2 : Call Service

    // Step 3 : Get Response

    // Step 4 : Return Response

    //-----------------------------
    //Result class
    //Results.Ok();

    //Results.NotFound();

    //Results.BadRequest();

    //Results.Created();

    //Results.NoContent();

    //Results.Unauthorized();

    //Results.Json();

    public class AccountsController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly BankSettings _bankSettings;
        private readonly AccountFactory _factory;

        public AccountsController(IAccountService accountService, IOptions<BankSettings> options,AccountFactory factory)
        {
            _accountService = accountService;
            _bankSettings = options.Value;
            _factory = factory;
        }
        [HttpGet]
        public IActionResult GetAccounts()
        {
            var bankName = _bankSettings.BankName;
            var result = _accountService.GetAllAccounts();
            return Ok($"{bankName} - {result}");
        }
        [HttpGet("Success")] //200
        public IActionResult Success()
        {
            return Ok("Success");
        }
        [HttpGet("notfound")] //404
        public IActionResult NotFound()
        {
            return NotFound("Not Found");
        }
        [HttpGet("badrequest")] //400
        public IActionResult BadRequestDemo()
        {
            return BadRequest("Invalid Request");
        }

        [HttpGet("nocontent")] //204
        public IActionResult NoContentDemo()
        {
            return NoContent();
        }
        [HttpGet("{id:int}")]
        public IActionResult GetElementById(int id)
        {
            return Ok(id);
        }
        [HttpPost]
        public IActionResult CreateAccount(CreateAccountDto dto)
        {
            var account = _accountService.CreateAccount(dto);
            return Ok(account);
        }
        [HttpPut("{id}")]
        public IActionResult UpdateAccount(int id)
        {
            return Ok($"Account {id} updated");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteAccount(int id)
        {
            return Ok($"Account {id} Deleted");
        }
        //Query parameter
        [HttpGet("Search")]
        public IActionResult SearchAccount(string name)
        {
            return Ok($"Searching : {name}");
        }
        [HttpGet("Filter")]
        public IActionResult Filter([FromQuery]string city , bool isActive)
        {
            return Ok($"{city} {isActive}");
        }
        [HttpGet("create/{type}")]
        public IActionResult Create(string type)
        {
            var service = _factory.GetAccountService(type);

            var result = service.CreateAccount();

            return Ok(result);
        }
        [HttpGet("error")]
        public IActionResult Error() {
            throw new Exception("Database Error");
        }
    }
}




