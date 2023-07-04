namespace JobSearch.Application.Contracts;

public interface IGenericRepository<T> where T : class
{
    Task<T?> Get(int id, CancellationToken token);
    Task<IReadOnlyList<T>> GetAll(CancellationToken token);
    Task<T> Add(T entity);
    Task<bool> Exists(int id, CancellationToken token);
    void Update(T entity);
    void Delete(T entity);
    void SoftDelete(T entity);
}
