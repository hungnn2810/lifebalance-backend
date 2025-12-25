namespace LifeBalance.Application.UserTracking.Models;

public class UserTrackingDto
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public int Steps { get; set; }
    public int Calories { get; set; }
    public int WorkoutStreak { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}