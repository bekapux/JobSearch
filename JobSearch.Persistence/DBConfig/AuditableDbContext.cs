using JobSearch.Domain.Utility;
using Microsoft.EntityFrameworkCore;

namespace JobSearch.Persistence.DBConfig;

public abstract class AuditableDbContext : DbContext
{
    protected AuditableDbContext(DbContextOptions options) : base(options)
    {
    }

    public virtual async Task<int> SaveChangesAsync(string username = "SYSTEM")
    {
        foreach (var entry in base.ChangeTracker.Entries<BaseDomainEntity>()
                     .Where(q => q.State is EntityState.Added or EntityState.Modified))
        {
            entry.Entity.LastModifiedDate = DateTime.Now;

            if (entry.State != EntityState.Added) continue;
            entry.Entity.DateCreated = DateTime.Now;
        }

        var result = await base.SaveChangesAsync();

        return result;
    }
}
