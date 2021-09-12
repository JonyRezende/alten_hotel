namespace Application.Models
{
    public class BookingResponse
    {
        public int BookingId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public int RoomNumber { get; set; }
        public string CreatedDate { get; set; }
        public string StartBookingDate { get; set; }
        public string EndBookingDate { get; set; }
    }
}
