using LifeBalance.Application.Services.Abstractions;
using LifeBalance.Application.UserInfo.Models;
using MediatR;

namespace LifeBalance.Application.UserInfo.Queries.Handlers;

public class GetUserInfoHandler(IUserService service) : IRequestHandler<GetUserInfoQuery, UserInfoDto>
{
    public async Task<UserInfoDto> Handle(GetUserInfoQuery request, CancellationToken cancellationToken)
    {
        return await service.FindInfoAsync(request);
    }
}