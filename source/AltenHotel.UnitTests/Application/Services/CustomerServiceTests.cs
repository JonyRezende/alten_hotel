using Arch.EntityFrameworkCore.UnitOfWork;
using Domain.Entities;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

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
