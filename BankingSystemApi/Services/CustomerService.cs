using BankingSystemApi.Data;
using BankingSystemApi.DTOs;
using BankingSystemApi.Models;
using BankingSystemApi.Services.Interfaces;

namespace BankingSystemApi.Services
{
    public class CustomerService:ICustomerService
    {
        private readonly BankingDbContext _dbContext;
        public CustomerService(BankingDbContext dbContext )
        {
            _dbContext = dbContext;

        }
        public List<Customer> GetAllCustomers()
        {
            return _dbContext.Customers.ToList();
        }
        public Customer CreateCustomer(CreateCustomerDto dto)
        {
            var Customerdata = new Customer();
            Customerdata.FullName = dto.FullName;
            Customerdata.Email = dto.Email;
            Customerdata.PhoneNumber = dto.PhoneNumber;
            Customerdata.Address = dto.Address;

            Customerdata.CreatedAt = DateTime.Now;
            Customerdata.isActive = true;


            _dbContext.Customers.Add(Customerdata);
            _dbContext.SaveChanges();
            return Customerdata;



        }
        public Customer? GetCustomerById(int id)
        {
           return _dbContext.Customers.Find(id);
        }
        public Customer? UpdateCustomer(int id, CreateCustomerDto dto)
        {
            var customer = _dbContext.Customers.Find(id);

            if (customer == null)
            {
                return null;
            }

            customer.FullName = dto.FullName;
            customer.Email = dto.Email;
            customer.PhoneNumber = dto.PhoneNumber;
            customer.Address = dto.Address;

            _dbContext.SaveChanges();

            return customer;
        }
        public bool DeleteCustomer(int id)
        {
            // Step 1: Find(id)

            // Step 2: Agar customer null hai
            // return false;

            // Step 3: Remove(customer)

            // Step 4: SaveChanges()

            // Step 5: return true;
            var data = _dbContext.Customers.Find(id);
            if (data == null)
            {
                return false;
            }
           _dbContext.Remove(data);
           _dbContext.SaveChanges();
           return true;
            

        }
    }
}
