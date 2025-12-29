using System.ComponentModel.DataAnnotations;
using LifeBalance.Domain.Enums;

namespace LifeBalance.Domain.Entities;

public class User : IEntity<Guid>
{
    public Guid Id { get; set; }
    [StringLength(128)] public string Email { get; set; }
    [StringLength(128)] public string Name { get; set; }
    [StringLength(1024)] public string Password { get; set; }
    [StringLength(8)] public string Language { get; set; } = "en";
    public Role Role { get; set; } = Role.USER;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    public ICollection<UserLogin> UserLogins { get; set; }
    public UserInformation UserInformation { get; set; }
    public ICollection<UserTracking> UserTracking { get; set; }
    public ICollection<RefreshToken> RefreshTokens { get; set; }
}