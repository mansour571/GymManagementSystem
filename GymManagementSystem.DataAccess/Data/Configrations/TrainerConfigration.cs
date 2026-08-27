using GymManagementSystem.DataAccess.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GymManagementSystem.DataAccess.Data.Configrations
{
    public class TrainerConfigration : UserConfigration<Trainer>
    {
        public override void Configure(EntityTypeBuilder<Trainer> builder)
        {
            base.Configure(builder);

            builder.Property(t => t.Speciality)
                .HasConversion<string>()
                .HasMaxLength(30);
        }
    }
}
