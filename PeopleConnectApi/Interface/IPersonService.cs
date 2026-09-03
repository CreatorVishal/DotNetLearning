using PeopleConnectApi.Models;

namespace PeopleConnectApi.Interface
{
    public interface IPersonService
    {
        Task<List<Person>> GetAllAsync();

        Task<Person?> GetByIdAsync(int id);

        Task<Person> AddAsync(Person person);

        Task UpdateAsync(Person person);

        Task DeleteAsync(int id);
    }
}