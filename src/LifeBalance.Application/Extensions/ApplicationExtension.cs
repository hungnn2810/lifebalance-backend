using System.Reflection;
using LifeBalance.Application.Services;
using LifeBalance.Application.Services.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace LifeBalance.Application.Extensions;

public static class ApplicationExtension
{
    public static void AddApplicationService(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

        serviceCollection.AddScoped<IJwtService, JwtService>();
        serviceCollection.AddScoped<IUserService, UserService>();
        serviceCollection.AddScoped<IExternalAuthService, GoogleAuthService>();
    }
}