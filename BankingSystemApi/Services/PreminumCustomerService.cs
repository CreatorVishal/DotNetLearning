using BankingSystemApi.DTOs;
using BankingSystemApi.Models;
using BankingSystemApi.Services.Interfaces;

namespace BankingSystemApi.Services
{
    public class PremiumCustomerService : ICustomerService
    {
        public List<Customer> GetAllCustomers()
        {
            Console.WriteLine("Premium Customer Service Called");

            return new List<Customer>();
        }

        public Customer CreateCustomer(CreateCustomerDto dto)
        {
            throw new NotImplementedException();
        }

        public Customer? GetCustomerById(int id)
        {
            throw new NotImplementedException();
        }

        public Customer? UpdateCustomer(int id, CreateCustomerDto dto)
        {
            throw new NotImplementedException();
        }

        public bool DeleteCustomer(int id)
        {
            throw new NotImplementedException();
        }
    }
}