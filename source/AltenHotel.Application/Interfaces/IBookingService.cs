using Application.Models;
using Domain.Entities;
using System.Threading.Tasks;

namespace Application.Interfaces.Services
{
    public interface IBookingService
    {
        Task<BookingResponse> AddBookingAsync(PlaceReservationModel placeReservationModel, int customerId);
        Task UpdateBookingAsync(Booking booking, ModifyReservationModel modifyReservationModel);
        Task DeleteBookingAsync(Booking booking);
        Task<BookingResponse> GetBookingResponseByIdAsync(int id);
        Task<Booking> GetByIdAsync(int id);
    }
}
