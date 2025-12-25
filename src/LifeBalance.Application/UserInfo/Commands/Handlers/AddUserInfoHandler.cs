using LifeBalance.Application.Services.Abstractions;
using LifeBalance.Application.SharedKernel.Models;
using MediatR;

namespace LifeBalance.Application.UserInfo.Commands.Handlers;

public class AddUserInfoHandler(IUserService service) : IRequestHandler<AddUserInfoCommand, BaseResponse>
{
    public async Task<BaseResponse> Handle(AddUserInfoCommand request, CancellationToken cancellationToken)
    {
       return await service.AddInfoAsync(request);
    }
}