using System.ComponentModel.DataAnnotations;

namespace LifeBalance.Domain.Entities;

public class UserInformation : IEntity<Guid>
{
    public Guid Id { get; set; }
    [StringLength(1024)] public string Avatar { get; set; }
    public short Age { get; set; }
    public short Weight { get; set; }
    public short Height { get; set; }
    [StringLength(64)] public string FitnessGoals { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}