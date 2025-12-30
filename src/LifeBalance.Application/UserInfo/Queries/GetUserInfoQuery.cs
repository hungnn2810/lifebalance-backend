using LifeBalance.Application.UserInfo.Models;
using MediatR;

namespace LifeBalance.Application.UserInfo.Queries;

public class GetUserInfoQuery : IRequest<UserInfoDto>;