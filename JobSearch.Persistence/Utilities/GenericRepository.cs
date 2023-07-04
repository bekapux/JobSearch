using JobSearch.Application.Contracts;
using JobSearch.Domain.Utility;
using JobSearch.Persistence.DBConfig;
using Microsoft.EntityFrameworkCore;

namespace JobSearch.Persistence.Utilities;

public class GenericRepository<T> : IGenericRepository<T> where T : BaseDomainEntity
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

    public void Delete(T entity)
    {
        _dbContext.Set<T>().Remove(entity);
    }

    public async Task<bool> Exists(int id, CancellationToken token)
    {
        return await Get(id, token) != null;
    }

    public virtual async Task<T?> Get(int id, CancellationToken token)
    {
        return await _dbContext.Set<T>().FindAsync(new object[] { id }, token);
    }

    public async Task<IReadOnlyList<T>> GetAll(CancellationToken cancellation)
    {
        return await _dbContext.Set<T>().AsNoTracking().ToListAsync(cancellation);
    }

    public void SoftDelete(T entity)
    {
        entity.IsDeleted = true;
    }

    public virtual void Update(T entity)
    {
        _dbContext.Entry(entity).State = EntityState.Modified;
    }

    #endregion
}