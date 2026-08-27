using GymManagementSystem.DataAccess.Data.Contexts;
using GymManagementSystem.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GymManagementSystem.DataAccess.Data.Seeder
{
    public static class CategorySeeder
    {
        public static async Task SeedAsync(GymDbContext dbContext)
        {
            if (await dbContext.Categories.AnyAsync())
                return;

            var categories = new List<Category>
        {
            new Category { Name = "Yoga" },
            new Category { Name = "Cardio" },
            new Category { Name = "Strength Training" },
            new Category { Name = "CrossFit" },
            new Category { Name = "Boxing" }
        };

            await dbContext.Categories.AddRangeAsync(categories);
            await dbContext.SaveChangesAsync();
        }
    }
}
