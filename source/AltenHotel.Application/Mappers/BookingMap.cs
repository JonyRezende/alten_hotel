﻿using Application.Models;
using Domain.Entities;
using System;

namespace Application.Mappers
{
    public class BookingMap
    {
        public virtual Booking PlaceReservationToBookingMap(PlaceReservationModel placeReservationModel, int customerId)
        {
            return new Booking()
            {
                CustomerId = customerId,
                CreatedDate = DateTime.Now,
                RoomNumber = 1, //can be added roomID in case of more rooms
                StartBookingDate = placeReservationModel.StartBookingDate,
                EndBookingDate = placeReservationModel.EndBookingDate
            };
        }

        public virtual BookingResponse BookingToBookingResponseMap(Booking booking)
        {
            return new BookingResponse()
            {
                BookingId = booking.Id,
                CustomerName = booking.Customer.Name,
                CustomerEmail = booking.Customer.Email,
                RoomNumber = booking.RoomNumber,
                CreatedDate = booking.CreatedDate.ToShortDateString(),
                StartBookingDate = booking.StartBookingDate.ToShortDateString(),
                EndBookingDate = booking.EndBookingDate.ToShortDateString()
            };
        }

        public virtual Booking ModifyReservationToBookingMap(Booking updateBooking, ModifyReservationModel modifyReservationModel)
        {
            updateBooking.StartBookingDate = modifyReservationModel.NewStartBookingDate;
            updateBooking.EndBookingDate = modifyReservationModel.NewEndBookingDate;

            return updateBooking;
        }
    }
}