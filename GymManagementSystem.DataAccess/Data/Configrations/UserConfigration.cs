using GymManagementSystem.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace GymManagementSystem.DataAccess.Data.Configrations
{
    public class UserConfigration : IEntityTypeConfiguration<User> 
    {
        public void Configure(EntityTypeBuilder<User> builder) 
        {
           builder.Property(u => u.Name)
                .HasMaxLength(100);

            builder.Property(u => u.Email)
                .HasMaxLength(100);

            builder.Property(u => u.Phone)
                .HasMaxLength(20);

            builder.Property(u => u.Gender)
                   .HasConversion<string>()
                   .HasMaxLength(10)
                   .IsRequired();

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

            builder.HasDiscriminator<string>("UserType")
               .HasValue<Trainer>("Trainer")
               .HasValue<Member>("Member");

            builder.HasQueryFilter(u => !u.IsDeleted); // any Query on User will automatically filter out deleted users

        }

    }
}
