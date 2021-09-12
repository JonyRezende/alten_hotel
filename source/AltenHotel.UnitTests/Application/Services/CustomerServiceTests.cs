using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Services;
using Moq;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Xunit;

namespace AltenHotel.UnitTests.Domain.Services
{
    public class CustomerServiceTests
    {
        private readonly Mock<ICustomerRepository> _customerRepository;
        private readonly CustomerService _customerServices;


        public CustomerServiceTests()
        {
            _customerRepository = new Mock<ICustomerRepository>();
            _customerServices = new CustomerService(_customerRepository.Object);
        }

        [Fact]
        public void GetCustomerById_ShouldReturnCustomer()
        {
            //Arrange
            var customer = Mock.Of<Customer>();

            _customerRepository.Setup(x => x.FindAsync(
                It.IsAny<Expression<Func<Customer, bool>>>()))
                .Returns(Task.FromResult(customer));

            //Act
            var result = _customerServices.GetCustomerByIdAsync(customer.Id).GetAwaiter().GetResult();

            //Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void GetCustomerByEmail_ShouldReturnCustomer()
        {
            //Arrange
            var customer = Mock.Of<Customer>();

            _customerRepository.Setup(x => x.FindAsync(
                It.IsAny<Expression<Func<Customer, bool>>>()))
                .Returns(Task.FromResult(customer));

            //Act
            var result = _customerServices.GetCustomerByEmailAsync(customer.Email).GetAwaiter().GetResult();

            //Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void AddCustomer_WithNewCustomer_ShoudAddCustomer()
        {
            //Arrange
            var customer = Mock.Of<Customer>();

            _customerRepository.Setup(x => x.FindAsync(
                It.IsAny<Expression<Func<Customer, bool>>>()))
                .Returns(Task.FromResult<Customer>(null));

            _customerRepository.Setup(x => x.AddAsync(
                It.IsAny<Customer>()))
                .Returns(Task.FromResult(1));

            //Act
            var result = _customerServices.AddCustomerAsync(customer.Name, customer.Email).GetAwaiter().GetResult();

            //Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void AddCustomer_WithExistentCustomer_ShoudReturnCustomer()
        {
            //Arrange
            var customer = Mock.Of<Customer>();

            _customerRepository.Setup(x => x.FindAsync(
                It.IsAny<Expression<Func<Customer, bool>>>()))
                .Returns(Task.FromResult(customer));

            //Act
            var result = _customerServices.AddCustomerAsync(customer.Name, customer.Email).GetAwaiter().GetResult();

            //Assert
            Assert.NotNull(result);
            Assert.Equal(customer, result);
        }
    }
}
