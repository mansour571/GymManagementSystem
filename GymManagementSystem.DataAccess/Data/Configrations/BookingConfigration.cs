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
            builder.HasKey(b => b.Id);

            builder.Property(b => b.CreatedAt)
                .HasColumnName("BookingDate")
                .HasDefaultValueSql("GETDATE()");

            builder.Property(b => b.Attended)
                .IsRequired()
                .HasDefaultValue(false);

            builder.HasIndex(x => new
            {
                x.MemberId,
                x.SessionId
            })
                .IsUnique()
                .HasFilter("[IsDeleted] = 0"); // Unique constraint for MemberId and SessionId, excluding soft-deleted records


            builder.HasOne(b => b.Member)
                   .WithMany(m => m.Bookings)
                   .HasForeignKey(b => b.MemberId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(b => b.Session)
                   .WithMany(s => s.Bookings)
                   .HasForeignKey(b => b.SessionId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasQueryFilter(b => !b.IsDeleted);
        }
    }
}
