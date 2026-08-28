using GymManagementSystem.DataAccess.Models;
using GymManagementSystem.DataAccess.InterceptorsSENTINEL;
using Microsoft.EntityFrameworkCore;

namespace GymManagementSystem.DataAccess.Data.Contexts
{
    public class GymDbContext : DbContext
    {
        public GymDbContext(DbContextOptions<GymDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(GymDbContext).Assembly);

            modelBuilder.Entity<User>()
                .HasDiscriminator<string>("UserType")
                .HasValue<Trainer>("Trainer")
                .HasValue<Member>("Member");

            modelBuilder.Entity<User>()
            .HasQueryFilter(u => !u.IsDeleted); // any Query on User will automatically filter out deleted users
        }

        #region DbSets

        public DbSet<Plan> Plans { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; } // This will include both Members and Trainers using TPH (Table Per Hierarchy) inheritance strategy
        public DbSet<Trainer> Trainers { get; set; } // This is optional, but can be useful if you want to query only trainers directly
        public DbSet<Member> Members { get; set; } // This is optional, but can be useful if you want to query only members directly
        public DbSet<HealthRecord> HealthRecords { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<MemberShip> MemberShips { get; set; }
        public DbSet<Booking> Bookings { get; set; }


        #endregion

    }
}
