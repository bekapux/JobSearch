namespace JobSearch.Application.BaseModels;

public class PaginatedListResult<T>
{
    public List<T>? ResultList { get; set; }
    public int? TotalPages { get; set; }
    public int? TotalRecords { get; set; }
}
