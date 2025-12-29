using LifeBalance.Application.UserTracking.Commands;
using LifeBalance.Application.UserTracking.Models;
using LifeBalance.Application.UserTracking.Queries;

namespace LifeBalance.Application.Services.Abstractions;

public interface IUserTrackingService
{
    Task<UserTrackingDto> FindAsync(GetUserTrackingQuery query);
    Task<UserTrackingDto> AddOrUpdateAsync(AddOrUpdateUserTrackingCommand command);
}