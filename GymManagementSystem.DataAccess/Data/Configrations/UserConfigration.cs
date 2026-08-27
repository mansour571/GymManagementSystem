using GymManagementSystem.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GymManagementSystem.DataAccess.Data.Configrations
{
    public class UserConfigration<T> : IEntityTypeConfiguration<T> where T : User
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
           builder.Property(u => u.Name)
                .HasMaxLength(100);

            builder.Property(u => u.Email)
                .HasMaxLength(100);

            builder.Property(u => u.Phone)
                .HasMaxLength(20);

            builder.OwnsOne(u => u.Address, addressBuilder =>
            {
                addressBuilder.Property(a => a.City)
                    .HasColumnName("City")
                    .HasMaxLength(50);

                addressBuilder.Property(a => a.Street)
                    .HasColumnName("Street")
                    .HasMaxLength(100);

                addressBuilder.Property(a => a.BuildingNumber)
                    .HasColumnName("BuildingNumber");
            });

            builder.HasIndex(u => u.Email)
                .IsUnique();

            builder.HasIndex(u => u.Phone)
                .IsUnique();

            builder.ToTable(t =>
            {
                t.HasCheckConstraint(
                "User_Phone_CK",
                "LEN([Phone]) = 11 AND [Phone] LIKE '01[0125]%'"
                );
            });

        }

    }
}
