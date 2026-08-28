using GymManagementSystem.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GymManagementSystem.DataAccess.Data.Configrations
{
    public class HealthRecordConfiguration : IEntityTypeConfiguration<HealthRecord>
    {
        public void Configure(EntityTypeBuilder<HealthRecord> builder)
        {
            builder.Property(hr => hr.Height)
                   .HasPrecision(5, 2);

            builder.Property(hr => hr.Weight)
                   .HasPrecision(5, 2);

            builder.Property(x => x.Note)
                   .HasMaxLength(500);

            builder.Property(hr => hr.BloodType)
                   .HasConversion<string>()
                   .HasMaxLength(20)
                   .IsRequired();

            builder.ToTable(t =>
            {
                t.HasCheckConstraint(
                "CK_HealthRecord_Height",
                "[Height] > 0");

                t.HasCheckConstraint(
                "CK_HealthRecord_Weight",
                "[Weight] > 0"
                );
            });

            builder.HasQueryFilter(hr => !hr.IsDeleted);
        }
    }
}
