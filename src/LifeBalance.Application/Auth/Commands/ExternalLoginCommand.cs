using LifeBalance.Application.Auth.Models;
using LifeBalance.Domain.Enums;
using MediatR;

namespace LifeBalance.Application.Auth.Commands;

public class ExternalLoginCommand : IRequest<TokenResponse>
{
    public string IdToken { get; set; }
    public AuthProvider Provider { get; set; }
    public string ProviderKey { get; set; }
    public string Email { get; set; }
    public string Name { get; set; }
}