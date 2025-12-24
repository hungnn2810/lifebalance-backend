using System.ComponentModel.DataAnnotations;

namespace LifeBalance.Domain.Entities;

public class WorkoutStep : IEntity<Guid>
{
    public Guid Id { get; set; }
    public Guid WorkoutId { get; set; }
    [StringLength(256)] public string Title { get; set; }
    public short StepOrder { get; set; }
    [StringLength(1024)] public string Description { get; set; }
    [StringLength(int.MaxValue)] public string Image { get; set; }
    [StringLength(int.MaxValue)] public string Video { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}