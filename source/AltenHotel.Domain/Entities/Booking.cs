using System;

namespace Domain.Entities
{
    public class Booking
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int RoomNumber { get; set; } //can be replaced by RoomId (in case of more rooms are available)
        public DateTime CreatedDate { get; set; }
        public DateTime StartBookingDate { get; set; }
        public DateTime EndBookingDate { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
