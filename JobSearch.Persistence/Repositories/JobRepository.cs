using JobSearch.Application.Contracts;
using JobSearch.Domain;
using JobSearch.Persistence.DBConfig;
using JobSearch.Persistence.Utilities;

namespace JobSearch.Persistence.Repositories;

internal class JobRepository : GenericRepository<Job>, IJobRepository
{
    public JobRepository(JobSearchDbContext dbContext) : base(dbContext)
    {
    }
}
