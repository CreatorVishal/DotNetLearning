using PeopleConnectApi.Interface;
using PeopleConnectApi.Models;

namespace PeopleConnectApi.Services
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _repository;

        public PersonService(IPersonRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Person>> GetAllAsync()
        {
            var people = await _repository.GetAllAsync();

            return people;
        }

        public async Task<Person?> GetByIdAsync(int id)
        {
            if (id <= 0)
            {
                return null;
            }

            var person = await _repository.GetByIdAsync(id);

            return person;
        }

        public async Task<Person> AddAsync(Person person)
        {
            if (person == null)
            {
                throw new ArgumentNullException(nameof(person));
            }

            if (string.IsNullOrWhiteSpace(person.FirstName))
            {
                throw new ArgumentException("First name is required.");
            }

            if (string.IsNullOrWhiteSpace(person.LastName))
            {
                throw new ArgumentException("Last name is required.");
            }

            if (string.IsNullOrWhiteSpace(person.Email))
            {
                throw new ArgumentException("Email is required.");
            }

            if (person.DateOfBirth > DateTime.UtcNow)
            {
                throw new ArgumentException("Date of birth cannot be in the future.");
            }

            var existingPeople = await _repository.GetAllAsync();

            var emailExists = existingPeople.Any(x =>
                x.Email.Equals(person.Email, StringComparison.OrdinalIgnoreCase));

            if (emailExists)
            {
                throw new InvalidOperationException(
                    "A person with this email already exists.");
            }

            person.CreatedAt = DateTime.UtcNow;
            person.IsActive = true;

            return await _repository.AddAsync(person);
        }

        public async Task UpdateAsync(Person person)
        {
            if (person == null)
            {
                throw new ArgumentNullException(nameof(person));
            }

            if (person.Id <= 0)
            {
                throw new ArgumentException("Valid person ID is required.");
            }

            if (string.IsNullOrWhiteSpace(person.FirstName))
            {
                throw new ArgumentException("First name is required.");
            }

            if (string.IsNullOrWhiteSpace(person.LastName))
            {
                throw new ArgumentException("Last name is required.");
            }

            if (string.IsNullOrWhiteSpace(person.Email))
            {
                throw new ArgumentException("Email is required.");
            }

            var existingPerson = await _repository.GetByIdAsync(person.Id);

            if (existingPerson == null)
            {
                throw new KeyNotFoundException(
                    $"Person with ID {person.Id} was not found.");
            }

            var existingPeople = await _repository.GetAllAsync();

            var emailExists = existingPeople.Any(x =>
                x.Id != person.Id &&
                x.Email.Equals(person.Email, StringComparison.OrdinalIgnoreCase));

            if (emailExists)
            {
                throw new InvalidOperationException(
                    "Another person with this email already exists.");
            }

            await _repository.UpdateAsync(person);
        }

        public async Task DeleteAsync(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Valid person ID is required.");
            }

            var person = await _repository.GetByIdAsync(id);

            if (person == null)
            {
                throw new KeyNotFoundException(
                    $"Person with ID {id} was not found.");
            }

            await _repository.DeleteAsync(person);
        }
    }
}