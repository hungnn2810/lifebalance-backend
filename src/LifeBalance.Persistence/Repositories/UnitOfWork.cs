using LifeBalance.Application.Repositories.Abstractions;
using LifeBalance.Persistence.DbContexts;
using Microsoft.EntityFrameworkCore.Storage;

namespace LifeBalance.Persistence.Repositories;

public class UnitOfWork(
    AppDbContext context,
    IUserRepository users,
    IUserLoginRepository userLogins,
    IRefreshTokenRepository refreshTokens) : IUnitOfWork
{
    private AppDbContext Context { get; set; } = context;
    private IDbContextTransaction _transaction;

    public async Task BeginTransactionAsync()
    {
        _transaction = await Context.Database.BeginTransactionAsync();
    }

    public async Task CommitAsync()
    {
        await Context.SaveChangesAsync();
        if (_transaction != null)
        {
            await _transaction.CommitAsync();
            await _transaction.DisposeAsync();
        }
    }

    public async Task RollbackAsync()
    {
        if (_transaction != null)
        {
            await _transaction.RollbackAsync();
            await _transaction.DisposeAsync();
        }
    }

    public IUserRepository Users { get; private set; } = users;
    public IUserLoginRepository UserLogins { get; private set; } = userLogins;
    public IRefreshTokenRepository RefreshTokens { get; private set; } = refreshTokens;
}