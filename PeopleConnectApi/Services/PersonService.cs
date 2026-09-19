//using Microsoft.Extensions.Caching.Memory;

using PeopleConnectApi.Interface;
using PeopleConnectApi.Models;
using System.Text.Json;
using Microsoft.Extensions.Caching.Distributed;

namespace PeopleConnectApi.Services
{
    public class PersonService : IPersonService
    {
        //private readonly IMemoryCache _cache;
        private readonly IDistributedCache _cache;
        private readonly IPersonRepository _repository;

        //public PersonService(IPersonRepository repository, IMemoryCache cache)
        //{
        //    _repository = repository;
        //    _cache = cache;
        //}
        public PersonService(IPersonRepository repository, IDistributedCache cache)
        {
            _repository = repository;
            _cache = cache;
        }

        public async Task<List<Person>> GetAllAsync()
        {
            // 1. Redis cache se data lene ki koshish
            var cachedData = await _cache.GetStringAsync("all_people");

            // 2. Cache mein data mila to deserialize karke return
            if (cachedData is not null)
            {
                var cachedPeople =
                    JsonSerializer.Deserialize<List<Person>>(cachedData);

                if (cachedPeople is not null)
                {
                    return cachedPeople;
                }
            }

            // 3. Cache miss hua to database se data fetch
            var people = await _repository.GetAllAsync();

            // 4. C# list ko JSON string mein convert
            var jsonData = JsonSerializer.Serialize(people);

            // 5. JSON string ko Redis mein 5 minutes ke liye save
            await _cache.SetStringAsync(
                "all_people",
                jsonData,
                new DistributedCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5)
                });

            // 6. Database se mili list return
            return people;
        }
        //public async Task<List<Person>> GetAllAsync()
        //{
        //   if(_cache.TryGetValue("all_people",out List<Person> cachedPeople )&& cachedPeople is not null)
        //    {
        //        return cachedPeople;
        //    }
        //    var people = await _repository.GetAllAsync();
        //    _cache.Set("all_people", people,TimeSpan.FromMinutes(5));
        //    return people;
        //}

        public async Task<Person?> GetByIdAsync(int id)
        {
            if (id <= 0)
            {
                return null;
            }
            string cacheKey = $"person:{id}";
            var cachedData = await _cache.GetStringAsync(cacheKey);
            if(cachedData is not null)
            {
                var cachedPerson = JsonSerializer.Deserialize<Person>(cachedData);
                if(cachedPerson is not null)
                {
                    return cachedPerson;
                }
            }
            var person = await _repository.GetByIdAsync(id);
            if(person is not null)
            {
                var jsonData = JsonSerializer.Serialize(person);
                await _cache.SetStringAsync(cacheKey,jsonData, new DistributedCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(10)
                });
            }
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

           var addedPerson=await _repository.AddAsync(person);
            //_cache.Remove("all_people"); // Invalidate the cache for all people
            await _cache.RemoveAsync("all_people"); // Invalidate the cache for all people
            return addedPerson;
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
            await _cache.RemoveAsync("all_people");
            await _cache.RemoveAsync($"person:{person.Id}");
            
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
            await _cache.RemoveAsync("all_people");
            await _cache.RemoveAsync($"person:{id}");
        }
    }
}