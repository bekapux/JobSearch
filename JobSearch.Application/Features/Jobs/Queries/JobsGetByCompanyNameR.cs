namespace JobSearch.Application.Features.Jobs.Queries;

public sealed record JobsGetByCompanyNameR(
    string CompanyName
) : IRequest<IEnumerable<JobDto>>;

public sealed class JobsGetByCompanyNameRH : IRequestHandler<JobsGetByCompanyNameR, IEnumerable<JobDto>>
{
    #region Constructor

    private readonly IUnitOfWork _unitOfWork;
    private readonly IJobMapper _jobMapper;

    public JobsGetByCompanyNameRH(IUnitOfWork unitOfWork, IJobMapper jobMapper)
    {
        _unitOfWork = unitOfWork;
        _jobMapper = jobMapper;
    }

    #endregion

    public async Task<IEnumerable<JobDto>> Handle(JobsGetByCompanyNameR request, CancellationToken cancellationToken)
    {
        var jobs = await _unitOfWork.JobRepository.GetJobsByCompanyName(request.CompanyName);

        var result = _jobMapper.JobListToJobDtoList(jobs);

        return result;
    }
}
