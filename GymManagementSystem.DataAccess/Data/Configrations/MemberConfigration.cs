using GymManagementSystem.DataAccess.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GymManagementSystem.DataAccess.Data.Configrations
{
    public class MemberConfigration : UserConfigration<Member>
    {
        public override void Configure(EntityTypeBuilder<Member> builder)
        {
            base.Configure(builder);

            builder.Property(m => m.Photo)
                .HasMaxLength(500);
        }
    }
}
