namespace JobSearch.Application.Contracts;

public interface IUnitOfWork : IDisposable
{
    IJobRepository JobRepository { get; }
    Task SaveAsync();
}
