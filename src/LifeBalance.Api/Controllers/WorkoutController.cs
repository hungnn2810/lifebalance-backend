using LifeBalance.Application.Workouts.Commands;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LifeBalance.Api.Controllers;

[Authorize(Roles = "ADMIN")]
[ApiController]
[Route("[controller]")]
public class WorkoutController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> AddAsync([FromBody] AddWorkoutCommand command)
    {
        var response = await mediator.Send(command);
        return Ok(response);
    }
}