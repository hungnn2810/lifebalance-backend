using LifeBalance.Application.Auth.Models;
using MediatR;

namespace LifeBalance.Application.Auth.Commands;

public class LoginCommand : IRequest<TokenResponse>
{
    public string Email { get; set; }
    public string Password { get; set; }
}