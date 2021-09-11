using Application.Interfaces.Services;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<Customer> AddCustomerAsync(string name, string email)
        {
            var customer = await _customerRepository.FindAsync(c => c.Email == email);
            if (customer == null)
            {
                customer = new Customer
                {
                    Name = name,
                    Email = email
                };
                await _customerRepository.AddAsync(customer);
            }

            return customer;
        }

        public async Task<Customer> GetCustomerByIdAsync(int id)
        {
            return await _customerRepository.FindAsync(predicate: x => x.Id == id);
        }

        public async Task<Customer> GetCustomerByEmailAsync(string email)
        {
            return await _customerRepository.FindAsync(predicate: x => x.Email == email);
        }
    }
}