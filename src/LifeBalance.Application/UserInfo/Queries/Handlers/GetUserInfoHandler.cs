using LifeBalance.Application.Services.Abstractions;
using LifeBalance.Application.UserInfo.Models;
using MediatR;

namespace LifeBalance.Application.UserInfo.Queries.Handlers;

public class GetUserInfoHandler(IUserService service) : IRequestHandler<GetUserInfoByIdQuery, UserInfoDto>
{
    public async Task<UserInfoDto> Handle(GetUserInfoByIdQuery request, CancellationToken cancellationToken)
    {
        return await service.FindInfoAsync(request);
    }
}