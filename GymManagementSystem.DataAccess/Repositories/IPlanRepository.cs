using GymManagementSystem.DataAccess.Models;

namespace GymManagementSystem.DataAccess.Repositories
{
    public interface IPlanRepository
    {
        Task<IEnumerable<Plan>> GetAllAsync();
        Task<Plan?> GetById(int id);
        void Add(Plan plan);
        void Update(Plan plan);
        void Delete(Plan plan);
        Task<int> SaveChangesAsync();
    }
}
