using Application.Models;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IBookingMapper
    {
        Booking PlaceReservationToBookingMap(PlaceReservationModel placeReservationModel, int customerId);
        BookingResponse BookingToBookingResponseMap(Booking booking);
        Booking ModifyReservationToBookingMap(Booking updateBooking, ModifyReservationModel modifyReservationModel);
    }
}