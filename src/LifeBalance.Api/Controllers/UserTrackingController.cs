using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LifeBalance.Api.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
public class UserTrackingController(IMediator mediator) : ControllerBase
{
    
}