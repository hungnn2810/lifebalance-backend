using LifeBalance.Application.Auth.Models;
using LifeBalance.Application.Services.Abstractions;
using MediatR;

namespace LifeBalance.Application.Auth.Commands.Handlers;

public class ExternalLoginHandler(IUserService userService, IEnumerable<IExternalAuthService> externalAuthServices, IAuthService authService)
    : IRequestHandler<ExternalLoginCommand, TokenResponse>
{
    public async Task<TokenResponse> Handle(ExternalLoginCommand request, CancellationToken cancellationToken)
    {
        var externalAuthService = externalAuthServices.First(x => x.Provider == request.Provider);
        var authResult = await externalAuthService.ValidateAsync(request.IdToken);

        var user = await userService.FindOrCreateAsync(
            authResult.Provider,
            authResult.ProviderKey,
            authResult.Email,
            authResult.Name
        );

        return await authService.GenerateTokenAsync(user, authResult.Provider);
    }
}