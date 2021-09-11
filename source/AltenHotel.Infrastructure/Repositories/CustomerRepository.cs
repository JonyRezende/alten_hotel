using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infrastructure.Contexts;
using Infrastructure.Repositories.Core;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(HotelContext context)
            : base(context) { }

        public async Task AddCustomerAsync(Customer customer)
        {
            await AddAsync(customer);
        }

        public async Task<Customer> GetCustomerByEmailAsync(string email)
        {
            return await FindAsync(x => x.Email == email);
        }

        public async Task<Customer> GetCustomerByIdAsync(int id)
        {
            return await FindAsync(x => x.Id == id);
        }
    }
}
