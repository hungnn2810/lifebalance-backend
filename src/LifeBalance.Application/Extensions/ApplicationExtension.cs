using LifeBalance.Application.Constants;
using LifeBalance.Application.Services;
using LifeBalance.Application.Services.Abstractions;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace LifeBalance.Application.Extensions;

public static class ApplicationExtension
{
    public static void AddApplicationService(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddMediatR(typeof(ApplicationExtension).Assembly);

        serviceCollection.AddHttpClient(HttpClients.FACEBOOK, config => { config.BaseAddress = new Uri("https://graph.facebook.com"); });

        serviceCollection.AddScoped<IJwtService, JwtService>();
        serviceCollection.AddScoped<IUserService, UserService>();
        serviceCollection.AddScoped<IExternalAuthService, GoogleAuthService>();
        serviceCollection.AddScoped<IExternalAuthService, FacebookAuthService>();
    }
}