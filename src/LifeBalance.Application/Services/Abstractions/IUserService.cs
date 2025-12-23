using LifeBalance.Application.Auth.Commands;
using LifeBalance.Application.SharedKernel.Models;
using LifeBalance.Domain.Entities;
using LifeBalance.Domain.Enums;

namespace LifeBalance.Application.Services.Abstractions;

public interface IUserService
{
    Task<User> FindOrCreateAsync(AuthProvider provider, string providerKey, string email, string name);
    Task<BaseResponse> RegisterAsync(RegisterUser command);
}