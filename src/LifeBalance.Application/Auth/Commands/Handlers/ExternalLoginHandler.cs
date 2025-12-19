using LifeBalance.Application.Auth.Models;
using LifeBalance.Application.Services.Abstractions;
using MediatR;

namespace LifeBalance.Application.Auth.Commands.Handlers;

public class ExternalLoginHandler(IUserService userService, IEnumerable<IExternalAuthService> authServices, IJwtService jwtService)
    : IRequestHandler<ExternalLogin, LoginResponse>
{
    public async Task<LoginResponse> Handle(ExternalLogin request, CancellationToken cancellationToken)
    {
        var authService = authServices.First(x => x.Provider == request.Provider);
        var authResult = await authService.ValidateAsync(request.IdToken);

        var user = await userService.FindOrCreateAsync(
            authResult.Provider,
            authResult.ProviderKey,
            authResult.Email,
            authResult.Name
        );

        var token = jwtService.Generate(user, authResult.Provider);

        return new LoginResponse(token);
    }
}