using LifeBalance.Application.UserInfo.Models;
using MediatR;

namespace LifeBalance.Application.UserInfo.Queries;

public class GetUserInfoByIdQuery(Guid userId) : IRequest<UserInfoDto>
{
    public Guid UserId { get; set; } = userId;
}