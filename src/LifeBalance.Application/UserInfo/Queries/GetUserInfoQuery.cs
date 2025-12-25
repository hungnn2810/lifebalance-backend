using LifeBalance.Application.UserInfo.Models;
using MediatR;

namespace LifeBalance.Application.UserInfo.Queries;

public class GetUserInfoQuery(Guid userId) : IRequest<UserInfoDto>
{
    public Guid UserId { get; set; } = userId;
}