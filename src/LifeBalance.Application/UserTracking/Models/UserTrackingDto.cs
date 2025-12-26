using System.Linq.Expressions;

namespace LifeBalance.Application.UserTracking.Models;

public class UserTrackingDto
{
    public Guid Id { get; set; }
    public int Steps { get; set; }
    public int Calories { get; set; }
    public int WorkoutStreak { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    private static Expression<Func<Domain.Entities.UserTracking, UserTrackingDto>> Projection
    {
        get
        {
            return entity => new UserTrackingDto
            {
                Id = entity.Id,
                Steps = entity.Steps,
                Calories = entity.Calories,
                WorkoutStreak = entity.WorkoutStreak,
                CreatedAt = entity.CreatedAt,
                UpdatedAt = entity.UpdatedAt
            };
        }
    }
    
    public static UserTrackingDto Create(Domain.Entities.UserTracking entity)
    {
        return entity != null ? Projection.Compile().Invoke(entity) : null;
    }
}