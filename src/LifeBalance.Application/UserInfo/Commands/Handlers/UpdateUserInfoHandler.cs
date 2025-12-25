using LifeBalance.Application.Services.Abstractions;
using LifeBalance.Application.SharedKernel.Models;
using MediatR;

namespace LifeBalance.Application.UserInfo.Commands.Handlers;

public class UpdateUserInfoHandler(IUserService service) : IRequestHandler<UpdateUserInfoCommand, BaseResponse>
{
    public async Task<BaseResponse> Handle(UpdateUserInfoCommand request, CancellationToken cancellationToken)
    {
        return await service.UpdateInfoAsync(request);
    }
}