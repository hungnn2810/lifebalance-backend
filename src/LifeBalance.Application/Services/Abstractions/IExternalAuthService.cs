using LifeBalance.Application.Auth.Models;
using LifeBalance.Domain.Enums;

namespace LifeBalance.Application.Services.Abstractions;

public interface IExternalAuthService
{
    AuthProvider Provider { get; }
    Task<ExternalAuthResult> ValidateAsync(string token);
}