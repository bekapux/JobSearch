namespace JobSearch.Application.Contracts;

public interface IJobRepository : IGenericRepository<Job>
{
    Task<List<Job>> GetJobsByCompanyName(string companyNameFragment, CancellationToken cancellationToken);

    Task<PaginatedListResult<Job>> GetPaginated(
        int pageNumber,
        int itemsPerPage,
        CancellationToken cancellationToken = default
    );
}
