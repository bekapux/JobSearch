namespace JobSearch.Application.Features.Jobs.Commands;

public sealed record JobUpdateC(
    int Id
) : BaseJob, IRequest<bool>;

public sealed class JobUpdateCH : IRequestHandler<JobUpdateC, bool>
{
    #region Constructor

    private readonly IUnitOfWork _unitOfWork;
    private readonly IJobMapper _jobMapper;

    public JobUpdateCH(IUnitOfWork unitOfWork, IJobMapper jobMapper)
    {
        _unitOfWork = unitOfWork;
        _jobMapper = jobMapper;
    }

    #endregion

    public async Task<bool> Handle(JobUpdateC request, CancellationToken cancellationToken)
    {
        var validationResult = new BaseJobValidator().Validate(request);

        if (validationResult.IsValid == false)
        {
            throw new BadRequestException("Validation error occured", validationResult);
        }

        var job = await _unitOfWork
            .JobRepository
            .Get(request.Id, cancellationToken);

        if (job is null)
        {
            throw new NotFoundException(nameof(job), request.Id);
        }

        _jobMapper.JobUpdateC_To_Job(request, job);

        _unitOfWork.JobRepository.Update(job);

        return await _unitOfWork.SaveAsync(cancellationToken) == 1;
    }
}
