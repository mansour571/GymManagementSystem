using GymManagementSystem.DataAccess.Data.Contexts;
using GymManagementSystem.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace GymManagementSystem.DataAccess.Data.Seeder
{
    public static class PlanSeeder
    {
        public static async Task SeedAsync(GymDbContext dbContext)
        {

            if (!await dbContext.Plans.AnyAsync())
            {
                var plans = new List<Plan>
            {
                new Plan
                {
                    Name = "Basic Plan",
                    Price = 300.00m,
                    DurationDays = 30,
                    Description = "Access to gym equipment during staffed hours",
                    IsActive = true
                },
                new Plan
                {
                    Name = "Standard Plan",
                    Price = 500.00m,
                    DurationDays = 60,
                    Description = "Includes gym equipment and 2 group classes per week",
                    IsActive = true
                },
                new Plan
                {
                    Name = "Premium Plan",
                    Price = 900.00m,
                    DurationDays = 90,
                    Description = "Unlimited access to equipment, classes, and sauna",
                    IsActive = true
                },
                new Plan
                {
                    Name = "Annual Plan",
                    Price = 3000.00m,
                    DurationDays = 365,
                    Description = "Full year access with personal trainer sessions",
                    IsActive = true
                }
            };

                await dbContext.Plans.AddRangeAsync(plans);
                await dbContext.SaveChangesAsync(); 

            }
        }
    }
}