namespace LifeBalance.Application.Auth.Models;

public class TokenResponse(string accessToken, int expiresIn, string refreshToken)
{
    public string AccessToken { get; set; } = accessToken;
    public int ExpiresIn { get; set; } = expiresIn;
    public string RefreshToken { get; set; } = refreshToken;
}