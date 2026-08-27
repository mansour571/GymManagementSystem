using GymManagementSystem.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace GymManagementSystem.DataAccess.InterceptorsSENTINEL
{
    /// <summary>
    /// Interceptor that populates audit columns (CreatedAt, UpdatedAt, DeletedAt, IsDeleted) on entities derived from BaseEntity.
    /// Place this class under the folder InterceptorsSENTINEL as requested.
    /// </summary>
    public class AuditSaveChangesInterceptor : SaveChangesInterceptor
    {
        private DateTime UtcNow() => DateTime.UtcNow;

        private void UpdateAuditProperties(DbContext context)
        {
            if (context == null) return;

            var entries = context.ChangeTracker.Entries<BaseEntity>();

            var now = UtcNow();

            foreach (var entry in entries)
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.CreatedAt = now;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Entity.UpdatedAt = now;

                    // handle soft-delete pattern: if IsDeleted toggled to true, set DeletedAt
                    if (entry.Entity.IsDeleted && !entry.Entity.DeletedAt.HasValue)
                    {
                        entry.Entity.DeletedAt = now;
                    }
                }
            }
        }

        public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
        {
            UpdateAuditProperties(eventData.Context!);
            return base.SavingChanges(eventData, result);
        }

        public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData,
            InterceptionResult<int> result, CancellationToken cancellationToken = default)
        {
            UpdateAuditProperties(eventData.Context!);
            return base.SavingChangesAsync(eventData, result, cancellationToken);
        }
    }
}
