using LifeBalance.Application.Services.Abstractions;
using LifeBalance.Application.SharedKernel.Models;
using LifeBalance.Application.UserTracking.Models;
using MediatR;

namespace LifeBalance.Application.UserTracking.Commands.Handlers;

public class AddUserTrackingHandler(IUserTrackingService service) : IRequestHandler<AddOrUpdateUserTrackingCommand, BaseResponse>
{
    public async Task<BaseResponse> Handle(AddOrUpdateUserTrackingCommand request, CancellationToken cancellationToken)
    {
        return await service.AddOrUpdateAsync(request);
    }
}