using LifeBalance.Application.Auth.Commands;
using LifeBalance.Application.Repositories.Abstractions;
using LifeBalance.Application.Services.Abstractions;
using LifeBalance.Application.SharedKernel.Models;
using LifeBalance.Application.Users.Commands;
using LifeBalance.Domain.Entities;
using LifeBalance.Domain.Enums;

namespace LifeBalance.Application.Services;

public class UserService(IUnitOfWork unitOfWork) : IUserService
{
    public async Task<User> FindOrCreateAsync(AuthProvider provider, string providerKey, string email, string name)
    {
        await unitOfWork.BeginTransactionAsync();
        try
        {
            var userLogin = await unitOfWork.UserLogins.FindAsync(provider, providerKey);

            if (userLogin != null)
                return userLogin.User;

            var user = new User
            {
                Id = Guid.NewGuid(),
                Email = email,
                Name = name
            };

            await unitOfWork.Users.AddAsync(user);
            await unitOfWork.UserLogins.AddAsync(new UserLogin
            {
                Provider = provider,
                ProviderKey = providerKey,
                User = user
            });

            await unitOfWork.CommitAsync();
            return user;
        }
        catch
        {
            await unitOfWork.RollbackAsync();
            throw;
        }
    }

    public Task<BaseResponse> UpdateAsync(UpdateUser command)
    {
        throw new NotImplementedException();
    }
}