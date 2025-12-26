using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using LifeBalance.Application.Auth.Commands;
using LifeBalance.Application.Auth.Models;
using LifeBalance.Application.Exceptions;
using LifeBalance.Application.Exceptions.Helpers;
using LifeBalance.Application.Repositories.Abstractions;
using LifeBalance.Application.Services.Abstractions;
using LifeBalance.Application.SharedKernel.Models;
using LifeBalance.Domain.Entities;
using LifeBalance.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace LifeBalance.Application.Services;

public class AuthService : IAuthService
{
    private readonly IUnitOfWork _unitOfWork;

    private readonly int _tokenExpireMinutes;
    private readonly int _refreshExpireDays;
    private readonly string _secret;
    private readonly string _issuer;
    private readonly string _audience;

    public AuthService(IConfiguration configuration, IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;

        _tokenExpireMinutes = int.TryParse(configuration["Jwt:ExpireMinutes"], out var minutes) ? minutes : 60;
        _refreshExpireDays = int.TryParse(configuration["Jwt:RefreshExpireDays"], out var days) ? days : 60;
        _secret = configuration["Jwt:Secret"];
        _issuer = configuration["Jwt:Issuer"];
        _audience = configuration["Jwt:Audience"];
    }

    public async Task<TokenResponse> GenerateTokenAsync(User user, AuthProvider provider)
    {
        await _unitOfWork.BeginTransactionAsync();
        try
        {
            var accessToken = GenerateAccessToken(user, _tokenExpireMinutes, provider);
            var refreshToken = GenerateRefreshToken();
            var refreshTokenHash = HashRefreshToken(refreshToken);

            await _unitOfWork.RefreshTokens.AddAsync(new RefreshToken
            {
                UserId = user.Id,
                TokenHash = refreshTokenHash,
                ExpiresAt = DateTime.UtcNow.AddDays(_refreshExpireDays) // Refresh token valid for 30 days
            });

            await _unitOfWork.CommitAsync();

            return new TokenResponse(
                accessToken,
                expiresIn: _tokenExpireMinutes * 60,
                refreshToken
            );
        }
        catch (Exception)
        {
            await _unitOfWork.RollbackAsync();
            throw;
        }
    }

    private string GenerateAccessToken(User user, int expireMinutes, AuthProvider? provider = null)
    {
        var claims = new List<Claim>
        {
            new(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new(JwtRegisteredClaimNames.Email, user.Email ?? ""),
            new(JwtRegisteredClaimNames.Name, user.Name),
            new("language", user.Language),
            new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new(JwtRegisteredClaimNames.Iat, DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString(), ClaimValueTypes.Integer64)
        };

        if (provider.HasValue)
        {
            claims.Add(new Claim("auth_provider", provider.Value.ToString()));
        }

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secret));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: _issuer,
            audience: _audience,
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(expireMinutes),
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    private static string GenerateRefreshToken()
    {
        var bytes = RandomNumberGenerator.GetBytes(64);
        return Convert.ToBase64String(bytes);
    }

    private static byte[] HashRefreshToken(string refreshToken)
    {
        return SHA256.HashData(Encoding.UTF8.GetBytes(refreshToken));
    }

    public async Task<BaseResponse> RegisterAsync(RegisterCommand command)
    {
        await _unitOfWork.BeginTransactionAsync();
        try
        {
            var existEmail = await _unitOfWork.Users.AsQueryable()
                .Where(x => x.Email == command.Email).AnyAsync();
            if (existEmail)
            {
                throw EntityValidationExceptionHelper.GenerateException(nameof(command.Email),
                    ExceptionErrorCode.DetailCode.ERROR_VALIDATION_DUPLICATED);
            }

            var existName = await _unitOfWork.Users.AsQueryable()
                .Where(x => x.Name == command.Name).AnyAsync();
            if (existName)
            {
                throw EntityValidationExceptionHelper.GenerateException(nameof(command.Name),
                    ExceptionErrorCode.DetailCode.ERROR_VALIDATION_DUPLICATED);
            }

            var user = RegisterCommand.Create(command);
            user.Password = HashPassword(command.Password);

            await _unitOfWork.Users.AddAsync(user);
            await _unitOfWork.CommitAsync();

            return BaseResponse.Success;
        }
        catch (Exception)
        {
            await _unitOfWork.RollbackAsync();
            throw;
        }
    }

    public async Task<TokenResponse> LoginAsync(LoginCommand command)
    {
        await _unitOfWork.BeginTransactionAsync();
        try
        {
            var user = await _unitOfWork.Users.AsQueryable()
                .Where(x => x.Email == command.Email || x.Name == command.Email).FirstOrDefaultAsync();
            if (user == null)
            {
                throw new EntityInvalidException(ExceptionErrorCode.ERROR_ENTITY_INVALID);
            }

            var isPasswordValid = VerifyPassword(command.Password, user.Password);
            if (!isPasswordValid)
            {
                throw new EntityInvalidException(ExceptionErrorCode.ERROR_ENTITY_INVALID);
            }

            var accessToken = GenerateAccessToken(user, _tokenExpireMinutes);
            var refreshToken = GenerateRefreshToken();
            var refreshTokenHash = HashRefreshToken(refreshToken);

            await _unitOfWork.RefreshTokens.AddAsync(new RefreshToken
            {
                UserId = user.Id,
                TokenHash = refreshTokenHash,
                ExpiresAt = DateTime.UtcNow.AddDays(_refreshExpireDays) // Refresh token valid for 30 days
            });

            await _unitOfWork.CommitAsync();

            return new TokenResponse(
                accessToken,
                expiresIn: _tokenExpireMinutes * 60,
                refreshToken
            );
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<TokenResponse> RefreshTokenAsync(RefreshTokenCommand command)
    {
        await _unitOfWork.BeginTransactionAsync();
        try
        {
            var tokenHash = HashRefreshToken(command.Token);

            var refreshToken = await _unitOfWork.RefreshTokens.AsQueryable()
                .Include(x => x.User)
                .FirstOrDefaultAsync(x =>
                    x.TokenHash == tokenHash &&
                    x.ExpiresAt > DateTime.UtcNow &&
                    x.RevokedAt == null);
            if (refreshToken == null)
            {
                throw new EntityInvalidException(ExceptionErrorCode.ERROR_ENTITY_INVALID);
            }

            refreshToken.RevokedAt = DateTime.UtcNow;

            var accessToken = GenerateAccessToken(refreshToken.User, _tokenExpireMinutes);
            var newRefreshToken = GenerateRefreshToken();
            var newRefreshTokenHash = HashRefreshToken(newRefreshToken);

            await _unitOfWork.RefreshTokens.AddAsync(new RefreshToken
            {
                UserId = refreshToken.UserId,
                TokenHash = newRefreshTokenHash,
                ExpiresAt = DateTime.UtcNow.AddDays(_refreshExpireDays), // Refresh token valid for 30 days
            });

            // Remove expired or revoked tokens
            var tokensToRemove = await _unitOfWork.RefreshTokens.AsQueryable()
                .Where(x => x.UserId == refreshToken.UserId &&
                    (x.ExpiresAt <= DateTime.UtcNow || x.RevokedAt != null))
                .ToListAsync();
            
            tokensToRemove.Add(refreshToken);
            foreach (var token in tokensToRemove)
            {
                await _unitOfWork.RefreshTokens.RemoveAsync(token.Id);
            }

            await _unitOfWork.CommitAsync();

            return new TokenResponse(
                accessToken,
                expiresIn: _tokenExpireMinutes * 60,
                newRefreshToken
            );
        }
        catch (Exception)
        {
            await _unitOfWork.RollbackAsync();
            throw;
        }
    }

    private static string HashPassword(string password)
    {
        const int saltSize = 16; // 128-bit
        const int keySize = 32; // 256-bit
        const int iterations = 100_000;

        // 1. Generate salt
        var salt = RandomNumberGenerator.GetBytes(saltSize);

        // 2. Derive key
        var hash = Rfc2898DeriveBytes.Pbkdf2(
            password,
            salt,
            iterations,
            HashAlgorithmName.SHA256,
            keySize
        );

        // 3. Format: iterations.salt.hash
        return $"{iterations}.{Convert.ToBase64String(salt)}.{Convert.ToBase64String(hash)}";
    }

    private static bool VerifyPassword(string password, string hashedPassword)
    {
        var parts = hashedPassword.Split('.', 3);
        if (parts.Length != 3)
        {
            return false; // Invalid format
        }

        var iterations = int.Parse(parts[0]);
        var salt = Convert.FromBase64String(parts[1]);
        var hash = Convert.FromBase64String(parts[2]);

        var derivedHash = Rfc2898DeriveBytes.Pbkdf2(
            password,
            salt,
            iterations,
            HashAlgorithmName.SHA256,
            hash.Length
        );

        return CryptographicOperations.FixedTimeEquals(derivedHash, hash);
    }
}