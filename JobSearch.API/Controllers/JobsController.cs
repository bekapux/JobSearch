using JobSearch.Application.BaseModels;
using JobSearch.Application.Features.Jobs.Commands;
using JobSearch.Application.Features.Jobs.Mapper.Dtos;
using JobSearch.Application.Features.Jobs.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace JobSearch.API.Controllers;

[Route("api/Jobs")]
[ApiController]
public class JobsController : ControllerBase
{
    #region Constructor

    private readonly IMediator _mediator;

    public JobsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    #endregion

    #region Actions

    [HttpGet("get-all")]
    public async Task<ActionResult<IEnumerable<JobDto>>> GetAll(CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new JobsGetAllR(), cancellationToken);
        return Ok(result);
    }

    [HttpGet("get-paginated/{pageNumber:int}/{itemsPerPage:int}")]
    public async Task<ActionResult<PaginatedListResult<JobDto>>> GetPaginated(int pageNumber, int itemsPerPage, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new JobsGetPaginatedR(pageNumber, itemsPerPage), cancellationToken);
        return Ok(result);
    }

    [HttpGet("get-by-id/{id:int}")]
    public async Task<ActionResult<JobDto>> GetById(int id, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new JobGetByIDR(id), cancellationToken);
        return Ok(result);
    }

    [HttpGet("get-by-name/{companyName}")]
    public async Task<ActionResult<IEnumerable<JobDto>>> GetByName(string companyName, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new JobsGetByCompanyNameR(companyName), cancellationToken);
        return Ok(result);
    }

    [HttpPost("add")]
    public async Task<ActionResult<bool>> Add(JobAddC newJob, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(newJob, cancellationToken);
        return Ok(result);
    }

    [HttpPut("update")]
    public async Task<ActionResult<bool>> Update(JobUpdateC jobUpdateC, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(jobUpdateC, cancellationToken);
        return Ok(result);
    }

    [HttpPut("delete")]
    public async Task<ActionResult<bool>> Delete(JobDeleteC jobDeleteC, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(jobDeleteC, cancellationToken);
        return Ok(result);
    }

    #endregion
}
