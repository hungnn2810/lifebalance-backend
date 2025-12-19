using LifeBalance.Application.Repositories.Abstractions;
using LifeBalance.Domain.Entities;
using LifeBalance.Domain.Enums;
using LifeBalance.Persistence.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace LifeBalance.Persistence.Repositories;

public class UserLoginRepository(AppDbContext context) : GenericRepository<UserLogin, Guid>(context), IUserLoginRepository
{
    protected override void Update(UserLogin requestObject, UserLogin targetObject)
    {
        throw new NotImplementedException();
    }

    public async Task<UserLogin> FindAsync(AuthProvider provider, string providerKey)
    {
        return await context.UserLogins.AsQueryable().Include(x => x.User)
            .FirstOrDefaultAsync(x => x.Provider == provider && x.ProviderKey == providerKey);
    }
}