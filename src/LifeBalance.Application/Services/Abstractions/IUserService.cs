using LifeBalance.Domain.Entities;
using LifeBalance.Domain.Enums;

namespace LifeBalance.Application.Services.Abstractions;

public interface IUserService
{
    Task<User> FindOrCreateAsync(AuthProvider provider, string providerKey, string email, string name);
}