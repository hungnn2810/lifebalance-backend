using LifeBalance.Application.Services.Abstractions;
using LifeBalance.Application.SharedKernel.Models;
using LifeBalance.Application.UserTracking.Models;
using MediatR;

namespace LifeBalance.Application.UserTracking.Commands.Handlers;

public class AddUserTrackingHandler(IUserTrackingService service) : IRequestHandler<AddUserTrackingCommand, BaseResponse>
{
    public async Task<BaseResponse> Handle(AddUserTrackingCommand request, CancellationToken cancellationToken)
    {
        return await service.AddAsync(request);
    }
}