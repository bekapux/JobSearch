namespace JobSearch.Application.Features.Jobs.Queries;

public sealed record JobsGetAllR() 
    : IRequest<IEnumerable<JobDto>>;

public sealed class JobsGetAllRH : IRequestHandler<JobsGetAllR, IEnumerable<JobDto>>
{
    #region Constructor

    private readonly IUnitOfWork _unitOfWork;
    private readonly IJobMapper _jobMapper;

    public JobsGetAllRH(IUnitOfWork unitOfWork, IJobMapper jobMapper)
    {
        _unitOfWork = unitOfWork;
        _jobMapper = jobMapper;
    }

    #endregion

    public async Task<IEnumerable<JobDto>> Handle(JobsGetAllR request, CancellationToken cancellationToken)
    {
        var jobs = await _unitOfWork.JobRepository.GetAll(cancellationToken);

        var result = _jobMapper.JobList_To_JobDtoList(jobs);

        return result;
    }
}
