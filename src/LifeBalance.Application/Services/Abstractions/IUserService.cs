using LifeBalance.Application.SharedKernel.Models;
using LifeBalance.Application.UserInfo.Commands;
using LifeBalance.Application.UserInfo.Models;
using LifeBalance.Application.UserInfo.Queries;
using LifeBalance.Domain.Entities;
using LifeBalance.Domain.Enums;

namespace LifeBalance.Application.Services.Abstractions;

public interface IUserService
{
    Task<User> FindOrCreateAsync(AuthProvider provider, string providerKey, string email, string name);
    Task<BaseResponse> AddInfoAsync(AddUserInfoCommand command);
    Task<UserInfoDto> FindInfoAsync(GetUserInfoByIdQuery byIdQuery);
    Task<BaseResponse> UpdateInfoAsync(UpdateUserInfoCommand command);
}