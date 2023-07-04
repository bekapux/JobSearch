namespace JobSearch.Application.Features.Jobs.Queries;

public sealed record JobGetByIDR(
    int Id
) : IRequest<JobDto>;

public sealed class JobGetByIDRH : IRequestHandler<JobGetByIDR, JobDto>
{
    #region Constructor

    private readonly IJobRepository _jobRepository;
    private readonly IJobMapper _jobMapper;

    public JobGetByIDRH(IJobRepository jobRepository, IJobMapper jobMapper)
    {
        _jobRepository = jobRepository;
        _jobMapper = jobMapper;
    }

    #endregion

    public async Task<JobDto> Handle(JobGetByIDR request, CancellationToken cancellationToken)
    {
        var job = await _jobRepository.Get(request.Id, cancellationToken);

        if (job is null)
        {
            throw new NotFoundException(nameof(Job), request.Id);
        }

        var result = _jobMapper.Job_To_JobDto(job);

        return result;
    }
}
