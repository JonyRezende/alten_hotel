using Arch.EntityFrameworkCore.UnitOfWork;
using Domain.Entities;
using Moq;

namespace AltenHotel.UnitTests.Domain.Services
{
    public class CustomerServiceTests
    {
        private readonly Mock<IUnitOfWork> _unitOfWork;
        private readonly Mock<IRepository<Customer>> _customerRepository;

        public CustomerServiceTests()
        {
            _unitOfWork = new Mock<IUnitOfWork>();
            _customerRepository = new Mock<IRepository<Customer>>();
        }
    }
}
