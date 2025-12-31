using System.ComponentModel.DataAnnotations;
using LifeBalance.Domain.Enums;

namespace LifeBalance.Domain.Entities;

public class Workout : IEntity<Guid>
{
    public Guid Id { get; set; }
    [StringLength(128)] public string Code { get; set; }
    [StringLength(128)] public string Name { get; set; }
    [StringLength(256)] public string Title { get; set; }
    [StringLength(128)] public WorkoutType Type { get; set; }
    [StringLength(1024)] public string Notes { get; set; }
    [StringLength(1024)] public string[] Benefits { get; set; }
    public int EstimatedCalories { get; set; }
    public int Index { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    public ICollection<WorkoutStep> Steps { get; set; }
}