using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace Application.Models
{
    public class PlaceReservationModel
    {
        [JsonProperty("customer_name")]
        [Required(ErrorMessage = "customer_name is required", AllowEmptyStrings = false)]
        public string CustomerName { get; set; }

        [JsonProperty("customer_email")]
        [DataType(DataType.EmailAddress, ErrorMessage = "email format is invalid")]
        [Required(ErrorMessage = "customer_email is required", AllowEmptyStrings = false)]
        public string CustomerEmail { get; set; }

        [JsonProperty("start_booking_date")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        [Required(ErrorMessage = "start_booking_date is required")]
        public DateTime StartBookingDate { get; set; }

        [JsonProperty("end_booking_date")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        [Required(ErrorMessage = "end_booking_date is required")]
        public DateTime EndBookingDate { get; set; }
    }
}