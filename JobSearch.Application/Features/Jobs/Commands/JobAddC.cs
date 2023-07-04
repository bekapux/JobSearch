namespace JobSearch.Application.Features.Jobs.Commands;

public sealed record JobAddC()
    : BaseJob, IRequest<bool>;

public sealed class JobAddCH : IRequestHandler<JobAddC, bool>
{
    #region Constructor

    private readonly IUnitOfWork _unitOfWork;
    private readonly IJobMapper _jobMapper;

    public JobAddCH(IUnitOfWork unitOfWork, IJobMapper jobMapper)
    {
        _unitOfWork = unitOfWork;
        _jobMapper = jobMapper;
    }

    #endregion

    public async Task<bool> Handle(JobAddC request, CancellationToken cancellationToken)
    {
        var validationResult = new BaseJobValidator().Validate(request);

        if (validationResult.IsValid == false)
        {
            throw new BadRequestException("Validation error occured", validationResult);
        }

        var newJob = _jobMapper.JobAddC_To_Job(request);

        await _unitOfWork.JobRepository.Add(newJob);
        var isAdded = await _unitOfWork.SaveAsync(cancellationToken) == 1;
        return isAdded;
    }
}
