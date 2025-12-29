using LifeBalance.Application.Workouts.Commands;
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
}