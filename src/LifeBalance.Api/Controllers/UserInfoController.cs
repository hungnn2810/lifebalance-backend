using LifeBalance.Application.UserInfo.Commands;
using LifeBalance.Application.UserInfo.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LifeBalance.Api.Controllers;

[Authorize]
[ApiController]
[Route("user-info")]
public class UserInfoController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> AddAsync([FromBody] AddUserInfoCommand command)
    {
        var response = await mediator.Send(command);
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> FindAsync()
    {
        var response = await mediator.Send(new GetUserInfoQuery());
        return Ok(response);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateAsync([FromBody] UpdateUserInfoCommand command)
    {
        var response = await mediator.Send(command);
        return Accepted(response);
    }
}