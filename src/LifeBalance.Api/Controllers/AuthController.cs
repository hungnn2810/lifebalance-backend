using LifeBalance.Application.Auth.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LifeBalance.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController(IMediator mediator) : ControllerBase
{
    [HttpPost("external-login")]
    public async Task<IActionResult> ExternalLoginAsync([FromBody] ExternalLogin command)
    {
        var result = await mediator.Send(command);
        return Ok(result);
    }
}