using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Infrastructure.DataAccess
{
    public class BookingMap : IEntityTypeConfiguration<Booking>
    {
        public void Configure(EntityTypeBuilder<Booking> builder)
        {
            builder.ToTable("Booking");

            builder.HasKey(b => b.Id);

            builder.Property(b => b.RoomNumber)
                .HasDefaultValue(1);

            builder.Property(b => b.CustomerId);

            builder.Property(b => b.CreatedDate)
                .HasColumnType("datetime")
                .HasDefaultValue(DateTime.Now);

            builder.Property(b => b.StartBookingDate)
                .HasColumnType("datetime");

            builder.Property(b => b.EndBookingDate)
                .HasColumnType("datetime");

            builder.HasOne(d => d.Customer)
                .WithMany(b => b.Bookings)
                .HasForeignKey(b => b.CustomerId)
                .HasConstraintName("FK_Booking_Customer");
        }
    }
}
