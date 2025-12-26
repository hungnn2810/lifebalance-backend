using LifeBalance.Application.Services.Abstractions;
using LifeBalance.Application.UserTracking.Models;
using MediatR;

namespace LifeBalance.Application.UserTracking.Commands.Handlers;

public class UpdateUserTrackingHandler(IUserTrackingService service) : IRequestHandler<UpdateUserTrackingCommand, UserTrackingDto>
{
    public async Task<UserTrackingDto> Handle(UpdateUserTrackingCommand request, CancellationToken cancellationToken)
    {
        return await service.UpdateAsync(request);
    }
}