using Application.Models;
using Domain.Entities;

namespace AltenHotel.Mappers
{
    public static class CustomerMap
    {
        public static Customer MapNewCustomer(PlaceReservationModel placeReservationModel)
        {
            return new Customer()
            {
                Name = placeReservationModel.CustomerName,
                Email = placeReservationModel.CustomerEmail
            };
        }
    }
}
