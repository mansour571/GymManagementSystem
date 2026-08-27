using GymManagementSystem.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace GymManagementSystem.DataAccess.Data.Configrations
{
    internal class BookingConfigration : IEntityTypeConfiguration<Booking>
    {
        public void Configure(EntityTypeBuilder<Booking> builder)
        {
            builder.Property(b => b.Attended)
                .IsRequired()
                .HasDefaultValue(false);


            builder.HasOne(b => b.Member)
                .WithMany(m => m.Bookings)
                .HasForeignKey(b => b.MemberId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(b => new
            {
                b.MemberId,
                b.SessionId
            }).IsUnique();

            builder.ToTable(t =>
            {
                t.HasCheckConstraint(
                    "CK_Booking_Date",
                    "[Date] >= GETDATE()"
                );
            });


            builder.HasQueryFilter(b => !b.IsDeleted);
        }
    }
}
