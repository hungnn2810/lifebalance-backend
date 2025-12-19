namespace LifeBalance.Domain.Entities;

public class User : IEntity<Guid>
{
    public Guid Id { get; set; }
    public string Email { get; set; } // Nullable
    public string Name { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    public ICollection<UserLogin> UserLogins { get; set; }
}