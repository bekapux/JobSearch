namespace JobSearch.Application.Features.Jobs.Queries;

public sealed record JobsGetPaginatedR(
    int PageNumber,
    int ItemsPerPage
) : IRequest<PaginatedListResult<JobDto>>;

public sealed class JobsGetPaginatedRH : IRequestHandler<JobsGetPaginatedR, PaginatedListResult<JobDto>>
{
    #region Constructor

    private readonly IJobRepository _jobRepository;
    private readonly IJobMapper _jobMapper;

    public JobsGetPaginatedRH(IJobRepository jobRepository, IJobMapper jobMapper)
    {
        _jobRepository = jobRepository;
        _jobMapper = jobMapper;
    }

    #endregion

    public async Task<PaginatedListResult<JobDto>> Handle(JobsGetPaginatedR request, CancellationToken cancellationToken)
    {
        var result = await _jobRepository.GetPaginated(
            request.PageNumber, 
            request.ItemsPerPage, 
            cancellationToken
        );
        
        return _jobMapper.Jobs_To_JobDto(result);
    }
}