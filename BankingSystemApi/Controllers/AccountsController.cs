using BankingSystemApi.DTOs;
using BankingSystemApi.Filters;
using BankingSystemApi.Models;
using BankingSystemApi.Services.Factories;
using BankingSystemApi.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
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

    //----------------------------
    //Controller level Filters
    //[ServiceFilter(typeof(LoggingActionFilter))]
    //[TypeFilter(typeof(LoggingActionFilter), Arguments = new object[]
    //{
    //            "AccountsModule"
    //})]
    
    public class AccountsController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly BankSettings _bankSettings;
        private readonly AccountFactory _factory;
        private readonly ILogger<AccountsController> _logger;

        public AccountsController(IAccountService accountService, IOptions<BankSettings> options, AccountFactory factory,ILogger<AccountsController>logger)
        {
            _accountService = accountService;
            _bankSettings = options.Value;
            _factory = factory;
            _logger = logger;
        }
        [Authorize]
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
            // TRACE
            _logger.LogTrace("Entered CreateAccount() method");

            if (!ModelState.IsValid)
            {
                _logger.LogWarning("Account creation validation failed for {Email}", dto.Email);

                return BadRequest(ModelState);
            }
            // DEBUG
            _logger.LogDebug(
                "Calling AccountService.CreateAccount() for {AccountHolderName}", dto.AccountHolderName);

            // INFORMATION
            _logger.LogInformation("Creating account for {AccountHolderName}",dto.AccountHolderName);
            var account = _accountService.CreateAccount(dto);
            _logger.LogInformation("Account created successfully for {AccountHolderName}", dto.AccountHolderName); //Structured Logging

            // TRACE
            _logger.LogTrace("Exited CreateAccount() method");

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
        public IActionResult Filter([FromQuery] string city, bool isActive)
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
        public IActionResult Error()
        {
            throw new Exception("Database Error");
        }
        [HttpGet("admin")]
        [Authorize(Roles = "Admin")]
        public IActionResult AdminOnly()
        {
            return Ok("Welcome Admin");
        }
        [HttpGet("customer")]
        [Authorize(Roles ="Customer")]
        public IActionResult CustomerOnly()
        {
            return Ok("Welcome Customer");
        }

        [HttpGet("manage")]
        [Authorize(Policy = "CanManageAccounts")]
        public IActionResult ManageAccounts()
        {
            return Ok("You have permission to manage accounts.");
        }

    }
}




