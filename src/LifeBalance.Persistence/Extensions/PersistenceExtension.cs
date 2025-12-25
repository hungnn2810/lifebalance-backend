using LifeBalance.Application.Repositories.Abstractions;
using LifeBalance.Persistence.DbContexts;
using LifeBalance.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LifeBalance.Persistence.Extensions;

public static class PersistenceExtension
{
    public static void AddPersistenceService(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddDbContextPool<AppDbContext>((service, option) =>
        {
            var configuration = service.GetService<IConfiguration>();
            var connectionString = configuration["ConnectionStrings:Default"];
            option.UseNpgsql(connectionString)
                .EnableSensitiveDataLogging()
                .EnableDetailedErrors();
        });

        serviceCollection.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();
        serviceCollection.AddScoped<IUserRepository, UserRepository>();
        serviceCollection.AddScoped<IUserLoginRepository, UserLoginRepository>();
        serviceCollection.AddScoped<IUserInformationRepository, UserInformationRepository>();;
        serviceCollection.AddScoped<IUnitOfWork, UnitOfWork>();
    }
}