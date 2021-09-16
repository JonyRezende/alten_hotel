using Application.Interfaces;
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
        private readonly IBookingMapper _bookingMapper;

        public BookingService(
            IBookingRepository bookingRepository,
            IBookingMapper bookingMapper
            )
        {
            _bookingRepository = bookingRepository;
            _bookingMapper = bookingMapper;
        }

        public async Task<BookingResponse> AddBookingAsync(PlaceReservationModel placeReservationModel, int customerId)
        {
            //To make sure that Start at 00:00h and Finish at 23:59h
            placeReservationModel.StartBookingDate = placeReservationModel.StartBookingDate.Date;
            placeReservationModel.EndBookingDate = placeReservationModel.EndBookingDate.Date.AddDays(1).AddMilliseconds(-3);

            var booking = _bookingMapper.PlaceReservationToBookingMap(placeReservationModel, customerId);

            await _bookingRepository.AddAsync(booking);

            return _bookingMapper.BookingToBookingResponseMap(booking);
        }

        public async Task<BookingResponse> GetBookingResponseByIdAsync(int id)
        {
            var booking = await _bookingRepository.GetByIdAsync(id);
            
            return (booking != null ) ? _bookingMapper.BookingToBookingResponseMap(booking) : null;
        }

        public async Task UpdateBookingAsync(Booking booking, ModifyReservationModel modifyReservationModel)
        {
            booking = _bookingMapper.ModifyReservationToBookingMap(booking, modifyReservationModel);
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
