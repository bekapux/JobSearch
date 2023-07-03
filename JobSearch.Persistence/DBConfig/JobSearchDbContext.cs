using JobSearch.Domain;
using Microsoft.EntityFrameworkCore;

namespace JobSearch.Persistence.DBConfig;

public class JobSearchDbContext : AuditableDbContext
{
    public JobSearchDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Job>().HasQueryFilter(e => (e.IsDeleted == false));

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(JobSearchDbContext).Assembly);
    }

    public DbSet<Job> Jobs { get; set; }
}

