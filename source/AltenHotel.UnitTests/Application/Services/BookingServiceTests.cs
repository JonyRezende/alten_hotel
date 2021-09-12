using Application.Models;
using Application.Services;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace AltenHotel.UnitTests.Domain.Services
{
    public class BookingServiceTests
    {
        private readonly Mock<IBookingRepository> _bookingRepository;
        private readonly BookingService _bookingServices;

        public BookingServiceTests()
        {
            _bookingRepository = new Mock<IBookingRepository>();
            _bookingServices = new BookingService(_bookingRepository.Object);
        }

        [Fact]
        public async Task UpdateBooking_ShouldUpdateBooking()
        {
            //Arrange
            var booking = Mock.Of<Booking>();
            var modifyReservationModel = Mock.Of<ModifyReservationModel>();
            _bookingRepository.Setup(x => x.UpdateAsync(It.IsAny<Booking>()))
                .Returns(Task.FromResult(1));

            //Act
            await _bookingServices.UpdateBookingAsync(booking, modifyReservationModel);

            //Assert
            _bookingRepository.Verify(x => x.UpdateAsync(It.IsAny<Booking>()), Times.Once);
        }

        [Fact]
        public async Task DeleteBooking_ShouldDeleteBooking()
        {
            //Arrange
            var booking = Mock.Of<Booking>();
            _bookingRepository.Setup(x => x.DeleteAsync(It.IsAny<Booking>()))
                .Returns(Task.FromResult(1));

            //Act
            await _bookingServices.DeleteBookingAsync(booking);

            //Assert
            _bookingRepository.Verify(x => x.DeleteAsync(It.IsAny<Booking>()), Times.Once);
        }

        [Fact]
        public void GetBookingById_ShouldReturnBooking()
        {
            //Arrange
            var booking = Mock.Of<Booking>();

            _bookingRepository.Setup(x => x.GetByIdAsync(It.IsAny<int>()))
                .Returns(Task.FromResult(booking));

            //Act
            var result = _bookingServices.GetByIdAsync(booking.Id).GetAwaiter().GetResult();

            //Assert
            Assert.NotNull(result);
        }
    }
}
