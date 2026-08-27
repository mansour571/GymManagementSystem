using GymManagementSystem.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GymManagementSystem.DataAccess.Data.Configrations
{
    internal class SessionConfigration : IEntityTypeConfiguration<Session>
    {
        public void Configure(EntityTypeBuilder<Session> builder)
        {
            builder.Property(s => s.Description)
                .IsRequired()
                .HasMaxLength(500);

            builder.ToTable(t =>
            {
                t.HasCheckConstraint(
                    "CK_Session_Capacity",
                    "[Capacity] BETWEEN 1 AND 25"
                );

                t.HasCheckConstraint(
                "CK_Session_DateRange",
                "[EndDate] > [StartDate]"
                );
            });

            builder.HasQueryFilter(s => !s.IsDeleted);
        }
    }
}
