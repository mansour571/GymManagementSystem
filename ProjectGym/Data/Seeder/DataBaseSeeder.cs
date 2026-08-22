namespace ProjectGym.Data.Seeder
{
    public class DataBaseSeeder
    {
        public static async Task SeedAllAsync()
        {
            await PlanSeeder.SeedAsync();
        }
    }
}
