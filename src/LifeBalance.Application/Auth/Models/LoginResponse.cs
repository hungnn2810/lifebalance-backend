namespace LifeBalance.Application.Auth.Models;

public class LoginResponse(string accessToken)
{
    public string AccessToken { get; set; } = accessToken;
}