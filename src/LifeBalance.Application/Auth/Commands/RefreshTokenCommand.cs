using LifeBalance.Application.Auth.Models;
using MediatR;

namespace LifeBalance.Application.Auth.Commands;

public class RefreshTokenCommand : IRequest<TokenResponse>
{
    public string Token { get; set; }
}