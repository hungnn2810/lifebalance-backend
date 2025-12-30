using System.ComponentModel.DataAnnotations;

namespace LifeBalance.Domain.Entities;

public class WorkoutStep : IEntity<Guid>
{
    public Guid Id { get; set; }
    public Guid WorkoutId { get; set; }
    [StringLength(256)] public string Title { get; set; }
    public short StepOrder { get; set; }
    [StringLength(1024)] public string Description { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    public Workout Workout { get; set; }
    public ICollection<WorkoutStepMedia> Medias { get; set; }
}