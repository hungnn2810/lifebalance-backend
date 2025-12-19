using Google.Apis.Auth;
using LifeBalance.Application.Auth.Models;
using LifeBalance.Application.Services.Abstractions;
using LifeBalance.Domain.Enums;
using Microsoft.Extensions.Configuration;

namespace LifeBalance.Application.Services;

public class GoogleAuthService(IConfiguration config) : IExternalAuthService
{
    private readonly string _clientId = config["Authentication:Google:ClientId"]!;
    public AuthProvider Provider => AuthProvider.GOOGLE;

    public async Task<ExternalAuthResult> ValidateAsync(string token)
    {
        try
        {
            var payload = await GoogleJsonWebSignature.ValidateAsync(
                token,
                new GoogleJsonWebSignature.ValidationSettings
                {
                    Audience = [_clientId]
                });

            return new ExternalAuthResult(
                AuthProvider.GOOGLE,
                payload.Subject,
                payload.Email,
                payload.Name
            );
        }
        catch (Exception ex)
        {
            throw new UnauthorizedAccessException("Invalid Google token", ex);
        }
    }
}