using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using LifeBalance.Application.Services.Abstractions;
using LifeBalance.Domain.Entities;
using LifeBalance.Domain.Enums;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace LifeBalance.Application.Services;

public class JwtService(IConfiguration configuration) : IJwtService
{
    public string Generate(User user, AuthProvider provider)
    {
        var secret = configuration["Jwt:Secret"] ??
            throw new InvalidOperationException("Jwt_Secret is not configured");
        var issuer = configuration["Jwt:Issuer"] ??
            throw new InvalidOperationException("Jwt_Issuer is not configured");
        var audience = configuration["Jwt:Audience"] ??
            throw new InvalidOperationException("Jwt_Audience is not configured");
        if (!int.TryParse(configuration["Jwt:ExpireMinutes"], out var expireMinutes))
            throw new InvalidOperationException("Jwt:ExpireMinutes is invalid");

        var claims = new List<Claim>
        {
            new(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new(JwtRegisteredClaimNames.Email, user.Email ?? ""),
            new("auth_provider", provider.ToString())
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: issuer,
            audience: audience,
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(expireMinutes),
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}