using System.ComponentModel.DataAnnotations;
using LifeBalance.Domain.Enums;

namespace LifeBalance.Domain.Entities;

public class WorkoutStepMedia : IEntity<Guid>
{
    public Guid Id { get; set; }
    public Guid WorkoutStepId { get; set; }
    public MediaType MediaType { get; set; }
    [StringLength(512)] public string ObjectKey { get; set; } // workouts/{workoutId}/steps/{stepId}/images/1.webp
    [StringLength(512)] public string Url { get; set; }
    public int SortOrder { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    
    public WorkoutStep WorkoutStep { get; set; }
}