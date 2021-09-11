using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace Application.Models
{
    public class ModifyReservationModel
    {
        [JsonProperty("booking_id")]
        [Required]
        public int Id { get; set; }

        [JsonProperty("new_start_booking_date")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        [Required]
        public DateTime NewStartBookingDate { get; set; }

        [JsonProperty("new_end_booking_date")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        [Required]
        public DateTime NewEndBookingDate { get; set; }
    }
}
