using LifeBalance.Application.Auth.Commands;
using LifeBalance.Application.Auth.Models;
using LifeBalance.Application.SharedKernel.Models;
using LifeBalance.Domain.Entities;
using LifeBalance.Domain.Enums;

namespace LifeBalance.Application.Services.Abstractions;

public interface IAuthService
{
    Task<TokenResponse> GenerateTokenAsync(User user, AuthProvider provider);
    Task<BaseResponse> RegisterAsync(RegisterCommand command);
    Task<TokenResponse> LoginAsync(LoginCommand command);
    Task<TokenResponse> RefreshTokenAsync(RefreshTokenCommand command);
}