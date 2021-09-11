using Core.Interfaces;
using Domain.Entities;
using System;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repositories
{
    public interface IBookingRepository : IGenericRepository<Booking>
    {
        Task<Booking> GetByIdAsync(int id);
        Task<bool> CheckBookingByDate(DateTime startDate, DateTime endDate);
    }
}
