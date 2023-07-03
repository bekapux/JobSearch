using JobSearch.Application.Features.Jobs.Queries;
using JobSearch.Domain;
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

    [HttpGet("jobs")]
    public async Task<ActionResult<IEnumerable<Job>>> GetAll()
    {
        var result = await _mediator.Send(new JobsGetAllR());
        return Ok(result);
    }

    [HttpGet("job/{id:int}")]
    public async Task<ActionResult<IEnumerable<Job>>> GetById(int id)
    {
        var result = await _mediator.Send(new JobGetByIDR(id));
        return Ok(result);
    }

    #endregion
}
