
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LifeBalance.Api.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
public class UserController(IMediator mediator) : ControllerBase
{
    // [HttpPut("{id:guid}")]
    // public async Task<IActionResult> UpdateAsync([FromRoute] Guid id, [FromBody] UpdateUserInfoCommand command)
    // {
    //     command.Id = id;
    //     var response = await mediator.Send(command);
    //     return Accepted(response);
    // }
}