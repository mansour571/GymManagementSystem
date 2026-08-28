using GymManagementSystem.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GymManagementSystem.DataAccess.Data.Configrations
{
    public class MembershipConfiguration : IEntityTypeConfiguration<MemberShip>
    {
        public void Configure(EntityTypeBuilder<MemberShip> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.CreatedAt)
                .HasColumnName("StartDate");

            builder.ToTable(t =>
            {
                t.HasCheckConstraint(
                "CK_MemberShip_DateRange",
                "[EndDate] > [StartDate]"
                );
            });

            builder.HasIndex(x => new
            {
                x.MemberId,
                x.PlanId
            }).IsUnique();
        }
    }
}
