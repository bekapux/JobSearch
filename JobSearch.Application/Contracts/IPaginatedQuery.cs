namespace JobSearch.Application.Contracts;

public interface IPaginatedQuery<T>
{
    Task<PaginatedListResult<T>> GetPaginated(
        int pageNumber,
        int itemsPerPage, 
        CancellationToken cancellationToken = default
    );
}
