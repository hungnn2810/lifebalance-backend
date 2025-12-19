using LifeBalance.Application.Repositories.Abstractions;
using LifeBalance.Domain.Entities;
using LifeBalance.Persistence.DbContexts;

namespace LifeBalance.Persistence.Repositories;

public class UserRepository(AppDbContext context) : GenericRepository<User, Guid>(context), IUserRepository
{
    protected override void Update(User requestObject, User targetObject)
    {
        throw new NotImplementedException();
    }
}