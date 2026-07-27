using BankingSystemApi.DTOs;
using BankingSystemApi.Models;

namespace BankingSystemApi.Services.Interfaces
{
    public interface ICustomerService
    {
        public List<Customer> GetAllCustomers();
        //public string GetAllCustomers();
        public Customer CreateCustomer(CreateCustomerDto dto);
        public Customer? GetCustomerById(int id);
        public Customer? UpdateCustomer(int id, CreateCustomerDto dto);
        public bool DeleteCustomer(int id);

    }
}
