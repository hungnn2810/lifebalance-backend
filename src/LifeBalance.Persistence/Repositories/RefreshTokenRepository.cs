using LifeBalance.Application.Repositories.Abstractions;
using LifeBalance.Domain.Entities;
using LifeBalance.Persistence.DbContexts;

namespace LifeBalance.Persistence.Repositories;

public class RefreshTokenRepository(AppDbContext context) : GenericRepository<RefreshToken, Guid>(context), IRefreshTokenRepository
{
    protected override void Update(RefreshToken requestObject, RefreshToken targetObject)
    {
       targetObject.RevokedAt = requestObject.RevokedAt;
    }
}