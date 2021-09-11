using System.Collections.Generic;

namespace Domain.Entities
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public virtual List<Booking> Bookings { get; set; }

        //More information about the customer can be added, like DocumentID, phone, address
    }
}
