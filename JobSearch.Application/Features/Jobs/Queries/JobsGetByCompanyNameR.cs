namespace JobSearch.Application.Features.Jobs.Queries;

public sealed record JobsGetByCompanyNameR(
    string CompanyName
) : IRequest<IEnumerable<JobDto>>;

public sealed class JobsGetByCompanyNameRH : IRequestHandler<JobsGetByCompanyNameR, IEnumerable<JobDto>>
{
    #region Constructor

    private readonly IJobRepository _jobRepository;
    private readonly IJobMapper _jobMapper;

    public JobsGetByCompanyNameRH(IJobRepository jobRepository, IJobMapper jobMapper)
    {
        _jobRepository = jobRepository;
        _jobMapper = jobMapper;
    }

    #endregion

    public async Task<IEnumerable<JobDto>> Handle(JobsGetByCompanyNameR request, CancellationToken cancellationToken)
    {
        var jobs = await _jobRepository.GetJobsByCompanyName(request.CompanyName, cancellationToken);

        var result = _jobMapper.JobList_To_JobDtoList(jobs);

        return result;
    }
}
