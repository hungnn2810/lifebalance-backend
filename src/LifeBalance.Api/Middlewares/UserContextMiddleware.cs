using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using LifeBalance.Application.SharedKernel.Abstractions;
using Microsoft.AspNetCore.Authentication;

namespace LifeBalance.Api.Middlewares;

public class UserContextMiddleware(RequestDelegate next)
{
    public async Task InvokeAsync(HttpContext context)
    {
        if (context.User.Identity is not { IsAuthenticated: true })
        {
            await context.ChallengeAsync();
            return;
        }

        var id = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (id == null)
        {
            await context.ChallengeAsync();
            return;
        }
        
        var language = context.User.FindFirst("language")?.Value ?? "en";
        
        if (context.RequestServices.GetService(typeof(IUserContext)) is IUserContext userContext)
        {
            userContext.SetId(Guid.Parse(id));
            userContext.SetLanguage(language);
        }
        
        await next(context);
    }
}