using JobSearch.Application.BaseModels;
using Microsoft.EntityFrameworkCore;

namespace JobSearch.Persistence.Extensions;

internal static class QueryableExtensions
{
    public static IQueryable<T> Paginate<T>(this IQueryable<T> query, int? pageSize, int? pageNumber)
    {
        if (pageNumber == null || pageSize == null)
        {
            return query;
        }
        int skip = (pageNumber.Value - 1) * pageSize.Value;
        return query.Skip(skip).Take(pageSize.Value);
    }

    public static async Task<PaginatedListResult<T>> ToPaginatedListAsync<T>(this IQueryable<T> query, int pageNumber, int pageSize)
    {
        var totalRecords = await query.CountAsync();
        var totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);
        var resultList = await query.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();

        return new PaginatedListResult<T>
        {
            TotalRecords = totalRecords,
            TotalPages = totalPages,
            ResultList = resultList
        };
    }
}
