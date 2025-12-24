using LifeBalance.Application.Services.Abstractions;
using LifeBalance.Application.SharedKernel.Models;
using MediatR;

namespace LifeBalance.Application.Users.Commands.Handlers;

public class UpdateUserHandler(IUserService service) : IRequestHandler<UpdateUser, BaseResponse>
{
    public async Task<BaseResponse> Handle(UpdateUser request, CancellationToken cancellationToken)
    {
        return await service.UpdateAsync(request);
    }
}