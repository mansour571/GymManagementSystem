using GymManagementSystem.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace GymManagementSystem.DataAccess.Data.Contexts
{
    public class GymDbContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(GymDbContext).Assembly);
        }

        #region DbSets

        public DbSet<Plan> Plans { get; set; }

        #endregion

    }
}
