using Domain.Models;
using System;
using System.Threading.Tasks;

namespace Domain.Interfaces.Validations
{
    public interface IBookingValidation
    {
        Task<ValidationResponse> CheckValidDate(DateTime startDate, DateTime endDate);
    }
}
