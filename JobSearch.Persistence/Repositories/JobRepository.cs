using JobSearch.Application.Contracts;
using JobSearch.Domain;
using JobSearch.Persistence.DBConfig;
using JobSearch.Persistence.Utilities;
using Microsoft.EntityFrameworkCore;

namespace JobSearch.Persistence.Repositories;

internal class JobRepository : GenericRepository<Job>, IJobRepository
{
    #region Constructor

    public JobRepository(JobSearchDbContext dbContext) : base(dbContext)
    {
    }

    #endregion

    #region Methods

    #endregion
    public async Task<List<Job>> GetJobsByCompanyName(string companyNameFragment)
    {
        var jobs = await _dbContext.Jobs
            .Where(x=> 
                x.CompanyName!
                    .ToLower()
                    .Contains(companyNameFragment)
                )
            .ToListAsync();
        return jobs;
    }
}
