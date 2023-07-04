#pragma warning disable CS8603
#pragma warning disable CS1998
using JobSearch.Application.Contracts;
using JobSearch.Persistence.DBConfig;
using Microsoft.EntityFrameworkCore;
using System.Threading;

namespace JobSearch.Persistence.Utilities;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    #region Constructor

    internal readonly JobSearchDbContext _dbContext;

    public GenericRepository(JobSearchDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    #endregion

    #region Methods

    public virtual async Task<T> Add(T entity)
    {
        await _dbContext.AddAsync(entity);
        return entity;
    }

    public async Task Delete(T entity)
    {
        _dbContext.Set<T>().Remove(entity);
    }

    public async Task<bool> Exists(int id, CancellationToken token)
    {
        return await Get(id, token) != null;
    }

    public virtual async Task<T> Get(int id, CancellationToken token)
    {
        return await _dbContext.Set<T>().FindAsync(new object[] { id }, token);
    }

    public async Task<IReadOnlyList<T>> GetAll(CancellationToken cancellation)
    {
        return await _dbContext.Set<T>().AsNoTracking().ToListAsync(cancellation);
    }

    public virtual async Task Update(T entity)
    {
        _dbContext.Entry(entity).State = EntityState.Modified;
    }

    #endregion
}

#pragma warning restore CS8603
#pragma warning restore CS1998
