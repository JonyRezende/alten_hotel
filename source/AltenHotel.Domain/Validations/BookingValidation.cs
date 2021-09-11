using Domain.Interfaces.Repositories;
using Domain.Interfaces.Validations;
using Domain.Models;
using System;
using System.Threading.Tasks;

namespace Domain.Validations
{
    public class BookingValidation : IBookingValidation
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly ValidationResponse _validationResponse;

        public BookingValidation(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
            _validationResponse = new ValidationResponse();
        }

        public async Task<ValidationResponse> CheckValidDate(DateTime startDate, DateTime endDate)
        {
            if (startDate.Date <= DateTime.Now.Date)
            {
                _validationResponse.Valid = false;
                _validationResponse.Error = "Reservation has to start at least in the next day.";
                return _validationResponse;
            }

            if (startDate > endDate)
            {
                _validationResponse.Valid = false;
                _validationResponse.Error = "Start booking date can't be higher than End Booking Date";
                return _validationResponse;
            }

            if ((endDate - startDate).TotalDays > 3)
            {
                _validationResponse.Valid = false;
                _validationResponse.Error = "Reservation can't be longer than 3 days";
                return _validationResponse;
            }

            if (!await _bookingRepository.CheckBookingByDate(startDate, endDate))
            {
                _validationResponse.Valid = false;
                _validationResponse.Error = "Room already booked in this period";
                return _validationResponse;
            }

            return _validationResponse;
        }
    }
}
