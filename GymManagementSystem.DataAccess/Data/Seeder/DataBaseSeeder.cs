using GymManagementSystem.DataAccess.Data.Contexts;

namespace GymManagementSystem.DataAccess.Data.Seeder
{
    public class DataBaseSeeder
    {
        public static async Task SeedAllAsync(GymDbContext dbContext)
        {
            await PlanSeeder.SeedAsync(dbContext);
        }
    }
}
