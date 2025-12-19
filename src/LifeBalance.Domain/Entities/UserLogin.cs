using LifeBalance.Domain.Enums;

namespace LifeBalance.Domain.Entities;

public class UserLogin : IEntity<Guid>
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public AuthProvider Provider { get; set; }  // Google | Facebook | Apple
    public string ProviderKey { get; set; } // sub / id
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    
    public User User { get; set; }

    public UserLogin()
    {
    }

    public UserLogin(Guid userId, AuthProvider provider, string providerKey)
    {
        UserId = userId;
        Provider = provider;
        ProviderKey = providerKey;
    }
}