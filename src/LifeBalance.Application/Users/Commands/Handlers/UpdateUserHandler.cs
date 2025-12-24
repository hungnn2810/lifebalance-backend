using LifeBalance.Application.Services.Abstractions;
using LifeBalance.Application.SharedKernel.Models;
using MediatR;

namespace LifeBalance.Application.Users.Commands.Handlers;

public class UpdateUserHandler(IUserService service) : IRequestHandler<UpdateUserInformation, BaseResponse>
{
    public async Task<BaseResponse> Handle(UpdateUserInformation request, CancellationToken cancellationToken)
    {
        return await service.UpdateAsync(request);
    }
}