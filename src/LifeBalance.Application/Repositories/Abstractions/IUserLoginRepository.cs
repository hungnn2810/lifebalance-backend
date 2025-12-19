using LifeBalance.Domain.Entities;
using LifeBalance.Domain.Enums;

namespace LifeBalance.Application.Repositories.Abstractions;

public interface IUserLoginRepository : IRepository<UserLogin, Guid>
{
    Task<UserLogin> FindAsync(AuthProvider provider, string providerKey);
}