using LifeBalance.Application.Repositories.Abstractions;
using LifeBalance.Domain.Entities;
using LifeBalance.Persistence.DbContexts;

namespace LifeBalance.Persistence.Repositories;

public class UserTrackingRepository(AppDbContext context) : GenericRepository<UserTracking, Guid>(context), IUserTrackingRepository
{
    protected override void Update(UserTracking requestObject, UserTracking targetObject)
    {
        targetObject.Steps = requestObject.Steps;
        targetObject.Calories = requestObject.Calories;
        targetObject.WorkoutStreak = requestObject.WorkoutStreak;
        targetObject.UpdatedAt = DateTime.UtcNow;
    }
}