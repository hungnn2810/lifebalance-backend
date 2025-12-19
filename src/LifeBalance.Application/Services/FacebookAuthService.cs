using System.Net.Http.Json;
using LifeBalance.Application.Auth.Models;
using LifeBalance.Application.Constants;
using LifeBalance.Application.Services.Abstractions;
using LifeBalance.Domain.Enums;
using Microsoft.Extensions.Configuration;

namespace LifeBalance.Application.Services;

public class FacebookAuthService(IConfiguration config, IHttpClientFactory httpClientFactory) : IExternalAuthService
{
    private readonly string _appId = config["Authentication:Facebook:AppId"];
    private readonly string _appSecret = config["Authentication:Facebook:AppSecret"];
    private readonly string _version = config["Authentication:Facebook:ApiVersion"];
    public AuthProvider Provider => AuthProvider.FACEBOOK;

    public async Task<ExternalAuthResult> ValidateAsync(string token)
    {
        var facebookService = httpClientFactory.CreateClient(HttpClients.FACEBOOK);
        var debugUrl =
            $"{_version}/debug_token" +
            $"?input_token={token}" +
            $"&access_token={_appId}|{_appSecret}";

        var debug = await facebookService.GetFromJsonAsync<FacebookDebugResponse>(debugUrl);

        if (debug?.Data?.IsValid != true)
            throw new UnauthorizedAccessException("Invalid Facebook token");

        // 2️⃣ GET USER INFO
        var profileUrl =
            $"{_version}/me" +
            $"?fields=id,name,email" +
            $"&access_token={token}";

        var profile = await facebookService.GetFromJsonAsync<FacebookUserResponse>(profileUrl);

        return new ExternalAuthResult(
            AuthProvider.FACEBOOK,
            profile.Id, 
            profile.Email,
            profile.Name
        );
    }
    
    private class FacebookUserResponse
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }

    private class FacebookDebugResponse
    {
        public FacebookDebugData Data { get; set; }
    }

    private class FacebookDebugData
    {
        public bool IsValid { get; set; }
        public string UserId { get; set; }
        public string AppId { get; set; }
    }
}

