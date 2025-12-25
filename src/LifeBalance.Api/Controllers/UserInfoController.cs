using LifeBalance.Application.UserInfo.Commands;
using LifeBalance.Application.UserInfo.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LifeBalance.Api.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
public class UserInfoController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> AddAsync([FromBody] AddUserInfoCommand command)
    {
        var response = await mediator.Send(command);
        return Ok(response);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> FindByIdAsync([FromRoute] Guid id)
    {
        var query = new GetUserInfoByIdQuery(id);
        var response = await mediator.Send(query);
        return Ok(response);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateAsync([FromRoute] Guid id, [FromBody] UpdateUserInfoCommand command)
    {
        command.UserId = id;
        var response = await mediator.Send(command);
        return Accepted(response);
    }
}