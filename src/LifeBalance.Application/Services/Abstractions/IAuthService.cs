using LifeBalance.Application.Auth.Commands;
using LifeBalance.Application.SharedKernel.Models;
using LifeBalance.Domain.Entities;
using LifeBalance.Domain.Enums;

namespace LifeBalance.Application.Services.Abstractions;

public interface IAuthService
{
    string GenerateToken(User user, AuthProvider provider);
    Task<BaseResponse> RegisterAsync(RegisterUser command);
}