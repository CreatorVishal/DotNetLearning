using Microsoft.EntityFrameworkCore;
using PeopleConnectApi.Data;
using PeopleConnectApi.Interface;
using PeopleConnectApi.Models;

namespace PeopleConnectApi.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly PeopleConnectDbContext _context;
        public PersonRepository(PeopleConnectDbContext context)
        {
            _context = context;
        }

        public async Task<Person> AddAsync(Person person)
        {
            await _context.Peoples.AddAsync(person);
            await _context.SaveChangesAsync();
            return person;
        }

        public async Task DeleteAsync(Person person)
        {
            _context.Peoples.Remove(person);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Person>> GetAllAsync()
        {
            return await _context.Peoples.ToListAsync();
        }

        public async Task<Person?> GetByIdAsync(int id)
        {
            return await _context.Peoples.FindAsync(id);
        }

        public async Task UpdateAsync(Person person)
        {
            _context.Peoples.Update(person);
            await _context.SaveChangesAsync();
            
        }
    }
}
