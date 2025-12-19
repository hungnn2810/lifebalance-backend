using LifeBalance.Domain.Entities;
using LifeBalance.Domain.Enums;

namespace LifeBalance.Application.Services.Abstractions;

public interface IJwtService
{
    string Generate(User user, AuthProvider provider);
}