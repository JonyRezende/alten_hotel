using Domain.Interfaces.Repositories;
using Domain.Validations;
using NSubstitute;
using System;
using System.Threading.Tasks;
using Xunit;

namespace AltenHotel.UnitTests.Domain.Validations
{
    public class BookingValidationTests
    {
        private readonly BookingValidation _bookingValidation;
        private readonly IBookingRepository _bookingRepository;

        public BookingValidationTests()
        {
            _bookingRepository = Substitute.For<IBookingRepository>();
            _bookingValidation = new BookingValidation(_bookingRepository);
        }

        [Fact]
        public async Task CheckValidDate_WithValidDate_ShouldReturnTrue()
        {
            DateTime startBookingDate = DateTime.Now.AddDays(1);
            DateTime endBookingDate = DateTime.Now.AddDays(3);

            _bookingRepository.CheckBookingByDate(startBookingDate, endBookingDate).Returns(true);

            var response = await _bookingValidation.CheckValidDate(startBookingDate, endBookingDate);

            Assert.True(response.Valid);
        }

        [Fact]
        public async Task CheckValidDate_WithInvalidT_odayDate_ShouldReturnFalse()
        {
            DateTime startBookingDate = DateTime.Now;
            DateTime endBookingDate = DateTime.Now;

            var response = await _bookingValidation.CheckValidDate(startBookingDate, endBookingDate);

            Assert.False(response.Valid);
            Assert.Equal("Reservation has to start at least in the next day.", response.Error);
        }

        [Fact]
        public async Task CheckValidDate_WithInvalidDate_MoreThanThreeDays_ShouldReturnFalse()
        {
            DateTime startBookingDate = DateTime.Now.AddDays(1);
            DateTime endBookingDate = DateTime.Now.AddDays(5);

            var response = await _bookingValidation.CheckValidDate(startBookingDate, endBookingDate);

            Assert.False(response.Valid);
            Assert.Equal("Reservation can't be longer than 3 days", response.Error);
        }

        [Fact]
        public async Task CheckValidDate_WithInvalidDate_EndGreaterThanStart_ShouldReturnFalse()
        {
            DateTime startBookingDate = DateTime.Now.AddDays(1);
            DateTime endBookingDate = DateTime.Now.AddDays(-2);

            var response = await _bookingValidation.CheckValidDate(startBookingDate, endBookingDate);

            Assert.False(response.Valid);
            Assert.Equal("Start booking date can't be higher than End Booking Date", response.Error);
        }
    }
}
