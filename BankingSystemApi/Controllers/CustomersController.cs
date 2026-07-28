using BankingSystemApi.Data;
using BankingSystemApi.DTOs;
using BankingSystemApi.Models;
using BankingSystemApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BankingSystemApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
   
    public class CustomersController:ControllerBase
    {
        private readonly ICustomerService _customerService;
        public IWebHostEnvironment _environment;
        public CustomersController(ICustomerService customerService,IWebHostEnvironment environment)
        {
            _customerService = customerService;
            _environment = environment;
        }
        [HttpGet]
        public ActionResult<List<Customer>> GetAllCustomer()
        {
            var data = _customerService.GetAllCustomers();
            return Ok(data);
        }
        [HttpGet("{id}")]
        public ActionResult<Customer> GetCustomerById(int id)
        {
            // Step 1
            // Service call

            // Step 2
            // Customer null hai?

            // Step 3
            // Haan -> NotFound()

            // Step 4
            // Nahi -> Ok(customer)
            
            var data = _customerService.GetCustomerById(id);
            if (data == null)
            {
                return NotFound($"Customer with Id {id} not found.");
            }
            return Ok(data);
        }
        [HttpPut("{id}")]
        public ActionResult<Customer> UpdateCustomer(int id, CreateCustomerDto dto)
        {
            var customer = _customerService.UpdateCustomer(id, dto);

            if (customer == null)
            {
                return NotFound("Customer not found.");
            }

            return Ok(customer);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteCustomer(int id)
        {
            var isDeleted = _customerService.DeleteCustomer(id);

            if (!isDeleted)
            {
                return NotFound($"Customer with Id {id} not found.");
            }

            return NoContent();
        }
        [HttpPost("register")]
        public IActionResult RegisterCustomer([FromForm] CustomerRegistrationDto dto)
        {
            var file = dto.AadhaarPhoto;
            var originalFileName = file.FileName;
            return Ok(originalFileName);
        }
    }
}
