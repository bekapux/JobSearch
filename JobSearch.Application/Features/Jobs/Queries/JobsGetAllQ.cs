namespace JobSearch.Application.Features.Jobs.Queries;

public sealed record JobsGetAllR() 
    : IRequest<List<Job>>;

public sealed class JobsGetAllRH : IRequestHandler<JobsGetAllR, List<Job>>
{
    #region Constructor

    private readonly IUnitOfWork _unitOfWork;

    public JobsGetAllRH(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    #endregion

    public async Task<List<Job>> Handle(JobsGetAllR request, CancellationToken cancellationToken)
    {
        var jobs = await _unitOfWork.JobRepository.GetAll();
        return jobs.ToList();
    }
}
