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
    public async Task<ActionResult<IEnumerable<JobDto>>> GetAll()
    {
        var result = await _mediator.Send(new JobsGetAllR());
        return Ok(result);
    }

    [HttpGet("get-by-id/{id:int}")]
    public async Task<ActionResult<JobDto>> GetById(int id)
    {
        var result = await _mediator.Send(new JobGetByIDR(id));
        return Ok(result);
    }

    [HttpGet("get-by-name/{companyName}")]
    public async Task<ActionResult<IEnumerable<JobDto>>> GetByName(string companyName)
    {
        var result = await _mediator.Send(new JobsGetByCompanyNameR(companyName));
        return Ok(result);
    }

    #endregion
}
