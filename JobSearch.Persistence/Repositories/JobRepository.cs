using JobSearch.Application.BaseModels;
using JobSearch.Application.Contracts;
using JobSearch.Domain;
using JobSearch.Persistence.DBConfig;
using JobSearch.Persistence.Extensions;
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

    public async Task<List<Job>> GetJobsByCompanyName(string companyNameFragment, CancellationToken cancellationToken)
    {
        var jobs = await _dbContext.Jobs
            .Where(x =>
                x.CompanyName!
                    .ToLower()
                    .Contains(companyNameFragment)
                )
            .ToListAsync(cancellationToken);
        return jobs;
    }

    public async Task<PaginatedListResult<Job>> GetPaginated(int pageNumber, int itemsPerPage = 25, CancellationToken cancellationToken = default)
    {
        var result = await _dbContext.Jobs.ToPaginatedListAsync(pageNumber, itemsPerPage, cancellationToken);
        return result;
    }

    #endregion
}
