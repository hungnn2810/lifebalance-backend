using LifeBalance.Application.Exceptions;
using LifeBalance.Application.Repositories.Abstractions;
using LifeBalance.Application.Services.Abstractions;
using LifeBalance.Application.SharedKernel.Abstractions;
using LifeBalance.Application.SharedKernel.Models;
using LifeBalance.Application.UserInfo.Commands;
using LifeBalance.Application.UserInfo.Models;
using LifeBalance.Application.UserInfo.Queries;
using LifeBalance.Domain.Entities;
using LifeBalance.Domain.Enums;

namespace LifeBalance.Application.Services;

public class UserService(IUnitOfWork unitOfWork, IUserContext userContext) : IUserService
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

    public async Task<BaseResponse> AddInfoAsync(AddUserInfoCommand command)
    {
        await unitOfWork.BeginTransactionAsync();
        try
        {
            var entity = AddUserInfoCommand.Create(command);
            entity.Id = userContext.Id;
            
            await unitOfWork.UserInformation.AddAsync(entity);
            await unitOfWork.CommitAsync();

            return BaseResponse.Success;
        }
        catch
        {
            await unitOfWork.RollbackAsync();
            throw;
        }
    }

    public async Task<UserInfoDto> FindInfoAsync(GetUserInfoQuery query)
    {
        var entity = await unitOfWork.UserInformation.FindAsync(userContext.Id);
        return entity == null
            ? throw new EntityNotFoundException(ExceptionErrorCode.ERROR_ENTITY_NOT_FOUND)
            : UserInfoDto.Create(entity);
    }

    public async Task<BaseResponse> UpdateInfoAsync(UpdateUserInfoCommand command)
    {
        await unitOfWork.BeginTransactionAsync();
        try
        {
            _ = await unitOfWork.UserInformation.FindAsync(userContext.Id) ??
                throw new EntityNotFoundException(ExceptionErrorCode.ERROR_ENTITY_NOT_FOUND);

            var entity = UpdateUserInfoCommand.Create(command);
            await unitOfWork.UserInformation.UpdateAsync(userContext.Id, entity);
            await unitOfWork.CommitAsync();

            return BaseResponse.Success;
        }
        catch
        {
            await unitOfWork.RollbackAsync();
            throw;
        }
    }
}