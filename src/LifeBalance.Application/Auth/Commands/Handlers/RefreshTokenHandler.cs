using LifeBalance.Application.Auth.Models;
using LifeBalance.Application.Services.Abstractions;
using MediatR;

namespace LifeBalance.Application.Auth.Commands.Handlers;

public class RefreshTokenHandler(IAuthService service) : IRequestHandler<RefreshTokenCommand, TokenResponse>
{
    public async Task<TokenResponse> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
    {
        return await service.RefreshTokenAsync(request);
    }
}