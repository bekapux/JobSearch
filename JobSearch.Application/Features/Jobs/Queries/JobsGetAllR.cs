namespace JobSearch.Application.Features.Jobs.Queries;

public sealed record JobsGetAllR() 
    : IRequest<IEnumerable<JobDto>>;

public sealed class JobsGetAllRH : IRequestHandler<JobsGetAllR, IEnumerable<JobDto>>
{
    #region Constructor

    private readonly IJobRepository _jobRepository;
    private readonly IJobMapper _jobMapper;

    public JobsGetAllRH(IJobRepository jobRepository, IJobMapper jobMapper)
    {
        _jobRepository = jobRepository;
        _jobMapper = jobMapper;
    }

    #endregion

    public async Task<IEnumerable<JobDto>> Handle(JobsGetAllR request, CancellationToken cancellationToken)
    {
        var jobs = await _jobRepository.GetAll(cancellationToken);

        var result = _jobMapper.JobList_To_JobDtoList(jobs);

        return result;
    }
}
