namespace LifeBalance.Application.Repositories.Abstractions;

public interface IUnitOfWork
{
    Task CommitAsync();
    Task RollbackAsync();
    Task BeginTransactionAsync();
    
    IRefreshTokenRepository RefreshTokens { get; }
    IUserRepository Users { get; }
    IUserLoginRepository UserLogins { get; }
    IUserInformationRepository UserInformation { get; }
    IUserTrackingRepository UserTracking { get; }
}