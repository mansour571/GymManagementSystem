using GymManagementSystem.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GymManagementSystem.DataAccess.Data.Configrations
{
    public class PlanConfigration : IEntityTypeConfiguration<Plan>
    {
        public void Configure(EntityTypeBuilder<Plan> builder)
        {
            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(p => p.Description)
                .HasMaxLength(200);

            builder.Property(p => p.Price)
                .HasPrecision(10,2);

            builder.ToTable(tb => 
            {
                tb.HasCheckConstraint("PlanDurationDays", "DurationDays BETWEEN 1 AND 365");
            });

            builder.HasIndex(p => p.Name)
                .IsUnique();

            builder.HasQueryFilter(p => !p.IsDeleted);

        }
    }
}
