using LifeBalance.Application.SharedKernel.Models;
using LifeBalance.Application.Users.Commands;
using LifeBalance.Domain.Entities;
using LifeBalance.Domain.Enums;

namespace LifeBalance.Application.Services.Abstractions;

public interface IUserService
{
    Task<User> FindOrCreateAsync(AuthProvider provider, string providerKey, string email, string name);
    Task<BaseResponse> UpdateAsync(UpdateUserInformation command);
}