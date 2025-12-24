using LifeBalance.Application.Auth.Models;
using LifeBalance.Application.Services.Abstractions;
using MediatR;

namespace LifeBalance.Application.Auth.Commands.Handlers;

public class LoginHandler(IAuthService service) : IRequestHandler<LoginCommand, TokenResponse>
{
    public async Task<TokenResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        return await service.LoginAsync(request);
    }
}