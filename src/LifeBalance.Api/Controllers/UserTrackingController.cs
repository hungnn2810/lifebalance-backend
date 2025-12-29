using LifeBalance.Application.UserTracking.Commands;
using LifeBalance.Application.UserTracking.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LifeBalance.Api.Controllers;

[Authorize]
[ApiController]
[Route("user-tracking")]
public class UserTrackingController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAsync([FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
    {
        var response = await mediator.Send(new GetUserTrackingQuery(startDate, endDate));
        return Ok(response);
    }
    
    [HttpPost]
    public async Task<IActionResult> AddAsync([FromBody] AddUserTrackingCommand command)
    {
        var response = await mediator.Send(command);
        return Ok(response);
    }
}