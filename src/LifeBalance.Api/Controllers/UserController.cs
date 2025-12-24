using LifeBalance.Application.Users.Commands;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LifeBalance.Api.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize]
public class UserController(IMediator mediator) : ControllerBase
{
    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateAsync([FromRoute]Guid id,[FromBody] UpdateUser command)
    {
        command.Id = id;
        var response = await mediator.Send(command);
        return Accepted(response);
    }
}