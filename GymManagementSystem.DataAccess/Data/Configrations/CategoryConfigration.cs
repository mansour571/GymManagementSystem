using GymManagementSystem.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GymManagementSystem.DataAccess.Data.Configrations
{
    public class CategoryConfigration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(c => c.Name )
                .HasMaxLength(30);

            builder.HasQueryFilter(c => !c.IsDeleted);
        }


    }
}
