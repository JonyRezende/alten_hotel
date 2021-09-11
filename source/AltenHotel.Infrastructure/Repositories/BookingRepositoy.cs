using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infrastructure.Contexts;
using Infrastructure.Repositories.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class BookingRepository : GenericRepository<Booking>, IBookingRepository
    {
        public BookingRepository(HotelContext context)
            : base(context) { }

        public async Task<bool> CheckBookingByDate(DateTime startDate, DateTime endDate)
        {
            var booking = await FindAsync(predicate: x => startDate <= x.EndBookingDate && x.StartBookingDate <= endDate);
            if (booking == null)
                return true;
            else
                return false;
        }

        public async Task<Booking> GetByIdAsync(int id)
        {
            return await dbSet.Include(b => b.Customer).FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
