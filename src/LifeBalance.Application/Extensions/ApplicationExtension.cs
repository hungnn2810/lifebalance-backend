using FluentValidation;
using LifeBalance.Application.Auth.Commands;
using LifeBalance.Application.Auth.Validations;
using LifeBalance.Application.Constants;
using LifeBalance.Application.Services;
using LifeBalance.Application.Services.Abstractions;
using LifeBalance.Application.UserInfo.Commands;
using LifeBalance.Application.UserInfo.Validations;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace LifeBalance.Application.Extensions;

public static class ApplicationExtension
{
    public static void AddApplicationService(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddMediatR(typeof(ApplicationExtension).Assembly);

        serviceCollection.AddApplicationValidator();
        serviceCollection.AddScoped<IAuthService, AuthService>();
        serviceCollection.AddScoped<IUserService, UserService>();
        serviceCollection.AddScoped<IExternalAuthService, GoogleAuthService>();

        serviceCollection.AddHttpClient(HttpClients.FACEBOOK, config => { config.BaseAddress = new Uri("https://graph.facebook.com"); });
    }

    private static void AddApplicationValidator(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddSingleton<IValidator<RegisterCommand>, RegisterValidation>();
        serviceCollection.AddSingleton<IValidator<ExternalLoginCommand>, ExternalLoginValidation>();
        serviceCollection.AddSingleton<IValidator<LoginCommand>, LoginValidation>();
        serviceCollection.AddSingleton<IValidator<RefreshTokenCommand>, RefreshTokenValidation>();
        serviceCollection.AddSingleton<IValidator<AddUserInfoCommand>, AddUserInfoValidation>();
        serviceCollection.AddSingleton<IValidator<UpdateUserInfoCommand>, UpdateUserInfoValidation>();
    }
}