using BankingSystemApi.Models;
using Microsoft.Extensions.Options;
using BankingSystemApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
namespace BankingSystemApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    
    public class AccountsController:ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly BankSettings _bankSettings;
        public AccountsController(IAccountService accountService, IOptions<BankSettings> options)//constructor Injection 
        {
            _accountService = accountService;
            _bankSettings = options.Value;

        }
        [HttpGet]
        public IActionResult GetAccounts()
        {
            var bankName = _bankSettings.BankName;
            var result = _accountService.GetAllAccounts();
            return Ok($"{bankName} - {result}");
        }
    }
}
