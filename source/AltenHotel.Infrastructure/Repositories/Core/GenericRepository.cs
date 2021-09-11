using Core.Interfaces;
using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.Core
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected HotelContext _hotelContext;
        internal DbSet<T> dbSet;

        public GenericRepository(
            HotelContext hotelContext)
        {
            _hotelContext = hotelContext;
            dbSet = hotelContext.Set<T>();
        }

        public async Task AddAsync(T entity)
        {
            await dbSet.AddAsync(entity);
            await CompleteAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            dbSet.Remove(entity);
            await CompleteAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            dbSet.Update(entity);
            await CompleteAsync();
        }

        public virtual async Task<T> FindAsync(Expression<Func<T, bool>> predicate)
        {
            return await dbSet.FirstOrDefaultAsync(predicate);
        }

        public async Task CompleteAsync()
        {
            await _hotelContext.SaveChangesAsync();
        }
    }
}
