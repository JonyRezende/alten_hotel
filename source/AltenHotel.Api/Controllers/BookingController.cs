using Application.Interfaces.Services;
using Application.Models;
using Domain.Interfaces.Validations;
using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace AltenHotel.Api.Controllers
{
    public class BookingController : BaseController
    {
        private readonly IBookingService _bookingService;
        private readonly ICustomerService _customerService;
        private readonly IBookingValidation _bookingValidation;

        public BookingController(
            IBookingService bookingService,
            ICustomerService customerService,
            IBookingValidation bookingValidation)
        {
            _bookingService = bookingService;
            _customerService = customerService;
            _bookingValidation = bookingValidation;
        }

        [HttpGet]
        [Route("GetReservationById")]
        [ProducesResponseType(200, Type = typeof(BookingResponse))]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            try
            {
                var booking = await _bookingService.GetBookingResponseByIdAsync(id);
                if (booking is null)
                    return NotFound("Reservation not found");

                return Ok(booking);
            }
            catch (Exception exception)
            {
                return CreateExceptionMessage(exception);
            }
        }

        [HttpGet]
        [Route("CheckAvailabilityByDate")]
        [ProducesResponseType(200, Type = typeof(string))]
        [ProducesResponseType(400, Type = typeof(DefaultError))]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetByDateAsync([Required] DateTime startDate, [Required] DateTime endDate)
        {
            try
            {
                var validationResponse = await _bookingValidation.CheckValidDate(startDate, endDate);
                if (!validationResponse.Valid)
                    return BadRequest(new DefaultError { Message = validationResponse.Error });

                return Ok("Room available at this period");
            }
            catch (Exception exception)
            {
                return CreateExceptionMessage(exception);
            }
        }

        [HttpPost]
        [Route("PlaceReservation")]
        [ProducesResponseType(200, Type = typeof(BookingResponse))]
        [ProducesResponseType(400, Type = typeof(DefaultError))]
        [ProducesResponseType(500)]
        public async Task<IActionResult> CreateAsync(PlaceReservationModel placeReservationModel)
        {
            try
            {
                var validationResponse = await _bookingValidation.CheckValidDate(placeReservationModel.StartBookingDate, placeReservationModel.EndBookingDate);
                if (!validationResponse.Valid)
                    return BadRequest(new DefaultError { Message = validationResponse.Error });

                /* Can be improved creating a new endpoint, with customer register, and managing customers, in this case we can just set de ID of the customer */
                var customer = await _customerService.AddCustomerAsync(placeReservationModel.CustomerName, placeReservationModel.CustomerEmail);

                var booking = await _bookingService.AddBookingAsync(placeReservationModel, customer.Id);

                return Created("PlaceReservation", booking);
            }
            catch (Exception exception)
            {
                return CreateExceptionMessage(exception);
            }
        }

        [HttpPut]
        [Route("ModifyReservation")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> UpdateAsync(ModifyReservationModel modifyReservationModel)
        {
            try
            {
                var validationResponse = await _bookingValidation.CheckValidDate(modifyReservationModel.NewStartBookingDate, modifyReservationModel.NewEndBookingDate);
                if (!validationResponse.Valid)
                    return BadRequest(new DefaultError { Message = validationResponse.Error });

                var booking = await _bookingService.GetByIdAsync(modifyReservationModel.Id);
                if (booking is null)
                    return NotFound("Reservation not found");

                await _bookingService.UpdateBookingAsync(booking, modifyReservationModel);

                return NoContent();
            }
            catch (Exception exception)
            {
                return CreateExceptionMessage(exception);
            }
        }

        [HttpDelete]
        [Route("CancelReservation")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Delete(int bookingId)
        {
            try
            {
                var booking = await _bookingService.GetByIdAsync(bookingId);
                if (booking is null)
                    return NotFound("Reservation not found");

                await _bookingService.DeleteBookingAsync(booking);

                return NoContent();
            }
            catch (Exception exception)
            {
                return CreateExceptionMessage(exception);
            }
        }
    }
}
