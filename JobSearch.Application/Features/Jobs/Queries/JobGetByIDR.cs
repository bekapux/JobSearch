namespace JobSearch.Application.Features.Jobs.Queries;

public sealed record JobGetByIDR(
    int Id
) : IRequest<JobDto>;

public sealed class JobGetByIDRH : IRequestHandler<JobGetByIDR, JobDto>
{
    #region Constructor

    private readonly IUnitOfWork _unitOfWork;
    private readonly IJobMapper _jobMapper;

    public JobGetByIDRH(IUnitOfWork unitOfWork, IJobMapper jobMapper)
    {
        _unitOfWork = unitOfWork;
        _jobMapper = jobMapper;
    }

    #endregion

    public async Task<JobDto> Handle(JobGetByIDR request, CancellationToken cancellationToken)
    {
        var job = await _unitOfWork.JobRepository.Get(request.Id, cancellationToken);

        if (job is null)
        {
            throw new NotFoundException(nameof(Job), request.Id);
        }

        var result = _jobMapper.JobToJobDto(job);

        return result;
    }
}
