using LifeBalance.Application.Auth.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LifeBalance.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController(IMediator mediator) : ControllerBase
{
    [HttpPost("external-login")]
    public async Task<IActionResult> ExternalLoginAsync([FromBody] ExternalLoginCommand command)
    {
        var result = await mediator.Send(command);
        return Ok(result);
    }

    [HttpPost("register")]
    public async Task<IActionResult> RegisterAsync([FromBody] RegisterCommand command)
    {
        var result = await mediator.Send(command);
        return Ok(result);
    }

    [HttpPost("login")]
    public async Task<IActionResult> LoginAsync([FromBody] LoginCommand command)
    {
        var result = await mediator.Send(command);
        return Ok(result);
    }
    
    [HttpPost("refresh")]
    public async Task<IActionResult> RefreshTokenAsync([FromBody] RefreshTokenCommand command)
    {
        var result = await mediator.Send(command);
        return Ok(result);
    }
}