using Application.Interfaces.Services;
using Application.Mappers;
using Application.Models;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using System;
using System.Threading.Tasks;

namespace Application.Services
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository _bookingRepository;

        public BookingService(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }

        public async Task<BookingResponse> AddBookingAsync(PlaceReservationModel placeReservationModel, int customerId)
        {
            placeReservationModel.StartBookingDate = Convert.ToDateTime(placeReservationModel.StartBookingDate.Date);
            placeReservationModel.EndBookingDate = Convert.ToDateTime(placeReservationModel.EndBookingDate.Date.AddDays(1).AddMilliseconds(-3));

            var booking = new BookingMap().PlaceReservationToBookingMap(placeReservationModel, customerId);

            await _bookingRepository.AddAsync(booking);

            return new BookingMap().BookingToBookingResponseMap(booking);
        }

        public async Task<BookingResponse> GetBookingResponseByIdAsync(int id)
        {
            var booking = await _bookingRepository.GetByIdAsync(id);
            
            return (booking != null ) ? new BookingMap().BookingToBookingResponseMap(booking) : null;
        }

        public async Task UpdateBookingAsync(Booking booking, ModifyReservationModel modifyReservationModel)
        {
            booking = new BookingMap().ModifyReservationToBookingMap(booking, modifyReservationModel);
            await _bookingRepository.UpdateAsync(booking);
        }

        public async Task DeleteBookingAsync(Booking booking)
        {
            await _bookingRepository.DeleteAsync(booking);
        }

        public async Task<Booking> GetByIdAsync(int id)
        {
            return await _bookingRepository.GetByIdAsync(id);
        }
    }
}
