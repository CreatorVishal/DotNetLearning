using Microsoft.AspNetCore.Mvc;
using PeopleConnectApi.DTOs;
using PeopleConnectApi.Interface;
using PeopleConnectApi.Models;
using PeopleConnectApi.Services;

namespace PeopleConnectApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PeopleController : ControllerBase
    {
        private readonly IPersonService _personService;
        public PeopleController(IPersonService personService)
        {
            _personService = personService;
        }
        [HttpGet]
        public async Task<ActionResult<List<PersonResponse>>> GetAll()
        {
            var people = await _personService.GetAllAsync();
            var response = people.Select(person => new PersonResponse
            {
                Id = person.Id,
                FirstName = person.FirstName,
                LastName = person.LastName,
                Email = person.Email,
                PhoneNumber = person.PhoneNumber,
                DateOfBirth = person.DateOfBirth,
                CreatedAt = person.CreatedAt,
                IsActive = person.IsActive
            }).ToList();
            return Ok(response);
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<PersonResponse>> GetById(int id)
        {
            var person = await _personService.GetByIdAsync(id);
            if (person == null)
            {
                return NotFound($"Person with ID {id} was not found.");
            }
            var response = new PersonResponse
            {
                Id = person.Id,
                FirstName = person.FirstName,
                LastName = person.LastName,
                Email = person.Email,
                PhoneNumber = person.PhoneNumber,
                DateOfBirth = person.DateOfBirth,
                CreatedAt = person.CreatedAt,
                IsActive = person.IsActive
            };

            return Ok(response);
        }
        [HttpPost]
        public async Task<ActionResult<PersonResponse>> Create(CreatePersonRequest request)
        {
            var person = new Person
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber,
                DateOfBirth = request.DateOfBirth
            };
            var createdPerson = await _personService.AddAsync(person);
            var response = new PersonResponse
            {
                Id = createdPerson.Id,
                FirstName = createdPerson.FirstName,
                LastName = createdPerson.LastName,
                Email = createdPerson.Email,
                PhoneNumber = createdPerson.PhoneNumber,
                DateOfBirth = createdPerson.DateOfBirth,
                CreatedAt = createdPerson.CreatedAt,
                IsActive = createdPerson.IsActive
            };
            return CreatedAtAction(nameof(GetById), new { id = createdPerson.Id },response);


        }
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id,UpdatePersonRequest request)
        {
            var existingPerson = await _personService.GetByIdAsync(id);

            if (existingPerson == null)
            {
                return NotFound($"Person with ID {id} was not found.");
            }

            existingPerson.FirstName = request.FirstName;
            existingPerson.LastName = request.LastName;
            existingPerson.Email = request.Email;
            existingPerson.PhoneNumber = request.PhoneNumber;
            existingPerson.DateOfBirth = request.DateOfBirth;
            existingPerson.IsActive = request.IsActive;

            await _personService.UpdateAsync(existingPerson);

            return NoContent();
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var person = await _personService.GetByIdAsync(id);

            if (person == null)
            {
                return NotFound($"Person with ID {id} was not found.");
            }

            await _personService.DeleteAsync(id);

            return NoContent();
        }
    }
}

//[HttpGet]
//public async Task<IActionResult> GetAll()
//{
//    var people = await _personService.GetAllAsync();

//    return Ok(people);
//}
//[HttpGet]
//public async Task<IActionResult> GetAll()
//{
//    var people = await _personService.GetAllAsync();

//    return Ok(people);
//}
//[HttpGet("{id:int}")]
//public async Task<IActionResult> GetById(int id)
//{
//    var person = await _personService.GetByIdAsync(id);

//    if (person == null)
//    {
//        return NotFound();
//    }

//    return Ok(person);
//}
//[HttpPost]
//public async Task<IActionResult> Create(Person person)
//{
//    var createdPerson = await _personService.AddAsync(person);

//    return Ok(createdPerson);
//}