using LifeBalance.Domain.Enums;

namespace LifeBalance.Application.Auth.Models;

public record ExternalAuthResult(AuthProvider Provider, string ProviderKey, string Email, string Name);