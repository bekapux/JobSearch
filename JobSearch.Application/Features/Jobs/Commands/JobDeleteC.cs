namespace JobSearch.Application.Features.Jobs.Commands;

public sealed record JobDeleteC(
    bool deleteForever
) : BaseDto, IRequest<bool>;

public sealed class JobDeleteCH : IRequestHandler<JobDeleteC, bool>
{
    #region Constructor

    private readonly IUnitOfWork _unitOfWork;

    public JobDeleteCH(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    #endregion


    public async Task<bool> Handle(JobDeleteC request, CancellationToken cancellationToken)
    {
        var job = await _unitOfWork.JobRepository.Get(request.Id, cancellationToken);

        if(job is null)
        {
            throw new NotFoundException(nameof(job), request.Id);
        }

        if (request.deleteForever)
        {
            _unitOfWork.JobRepository.Delete(job);
        }
        else
        {
            _unitOfWork.JobRepository.SoftDelete(job);
        }

        return await _unitOfWork.SaveAsync(cancellationToken) == 1;
    }
}