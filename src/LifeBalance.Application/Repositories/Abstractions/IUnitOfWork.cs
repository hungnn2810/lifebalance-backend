namespace LifeBalance.Application.Repositories.Abstractions;

public interface IUnitOfWork
{
    Task CommitAsync();
    Task RollbackAsync();
    Task BeginTransactionAsync();
    
    IUserRepository Users { get; }
    IUserLoginRepository UserLogins { get; }
    IRefreshTokenRepository RefreshTokens { get; }
}