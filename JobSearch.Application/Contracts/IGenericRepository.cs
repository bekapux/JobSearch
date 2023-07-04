namespace JobSearch.Application.Contracts;

public interface IGenericRepository<T> where T : class
{
    Task<T> Get(int id, CancellationToken token);
    Task<IReadOnlyList<T>> GetAll(CancellationToken token);
    Task<T> Add(T entity);
    Task<bool> Exists(int id, CancellationToken token);
    Task Update(T entity);
    Task Delete(T entity);
}
