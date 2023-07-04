using JobSearch.Application.Contracts;
using JobSearch.Persistence.DBConfig;
using Microsoft.AspNetCore.Http;

namespace JobSearch.Persistence.Repositories;

public class UnitOfWork : IUnitOfWork
{
    #region Constructor

    private readonly JobSearchDbContext _context;

    public UnitOfWork(JobSearchDbContext context)
    {
        _context = context;
    }

    #endregion

    public IJobRepository JobRepository => new JobRepository(_context);

    #region Methods

    public void Dispose()
    {
        _context.Dispose();
        GC.SuppressFinalize(this);
    }

    public async Task<int> SaveAsync(CancellationToken cancellationToken)
    {
        return await _context.SaveChangesAsync(cancellationToken);
    }
    #endregion
}
