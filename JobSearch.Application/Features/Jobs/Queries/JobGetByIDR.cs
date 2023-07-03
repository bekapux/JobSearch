using JobSearch.Application.Exceptions;

namespace JobSearch.Application.Features.Jobs.Queries;

public sealed record JobGetByIDR(
    int Id
) : IRequest<Job>;

public sealed class JobGetByIDRH : IRequestHandler<JobGetByIDR, Job>
{
    #region Constructor

    private readonly IUnitOfWork _unitOfWork;

    public JobGetByIDRH(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    #endregion

    public async Task<Job> Handle(JobGetByIDR request, CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.JobRepository.Get(request.Id);

        if (result is null)
        {
            throw new NotFoundException(nameof(Job), request.Id);
        }

        return result;
    }
}
