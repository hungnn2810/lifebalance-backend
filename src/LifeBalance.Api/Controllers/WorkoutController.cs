using LifeBalance.Application.Workouts.Commands;
using LifeBalance.Application.Workouts.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LifeBalance.Api.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
public class WorkoutController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    [Authorize(Roles = "ADMIN")]
    public async Task<IActionResult> AddAsync([FromBody] AddWorkoutCommand command)
    {
        var response = await mediator.Send(command);
        return Ok(response);
    }

    [HttpPost("search")]
    public async Task<IActionResult> SearchAsync([FromBody] SearchWorkoutQuery query)
    {
        var response = await mediator.Send(query);
        return Ok(response);
    }
}