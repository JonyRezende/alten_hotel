using Application.Interfaces;
using Application.Interfaces.Services;
using Application.Mappers;
using Application.Services;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Validations;
using Domain.Services;
using Domain.Validations;
using Infrastructure.Contexts;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace AltenHotel.Api.Extensions
{
    public static class DependencyResolver
    {
        public static void ResolveServices(this IServiceCollection services, IConfiguration configuration)
        {
            //just for test porpuses, can be used SqlServer
            services.AddDbContext<HotelContext>(opt => opt.UseInMemoryDatabase("AltenHotel"));

            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IBookingRepository, BookingRepository>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IBookingService, BookingService>();
            services.AddScoped<IBookingValidation, BookingValidation>();
            services.AddScoped<IBookingMapper, BookingMapper>();


            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "AltenHotel.Api", Version = "v1" });
            });
        }
    }
}
