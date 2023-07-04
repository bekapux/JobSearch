using JobSearch.Application.Contracts;
using JobSearch.Persistence.DBConfig;
using Microsoft.AspNetCore.Http;

namespace JobSearch.Persistence.Repositories;

public class UnitOfWork : IUnitOfWork
{
    #region Constructor

    private readonly JobSearchDbContext _context;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public UnitOfWork(JobSearchDbContext context, IHttpContextAccessor httpContextAccessor)
    {
        _context = context;
        _httpContextAccessor = httpContextAccessor;
    }

    #endregion

    public IJobRepository JobRepository => new JobRepository(_context);

    #region Methods

    public void Dispose()
    {
        _context.Dispose();
        GC.SuppressFinalize(this);
    }

    public async Task<int> SaveAsync()
    {
        return await _context.SaveChangesAsync();
    }
    #endregion
}
