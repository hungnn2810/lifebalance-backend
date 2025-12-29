using LifeBalance.Application.Services.Abstractions;
using LifeBalance.Application.UserTracking.Models;
using MediatR;

namespace LifeBalance.Application.UserTracking.Commands.Handlers;

public class AddUserTrackingHandler(IUserTrackingService service) : IRequestHandler<AddOrUpdateUserTrackingCommand, UserTrackingDto>
{
    public async Task<UserTrackingDto> Handle(AddOrUpdateUserTrackingCommand request, CancellationToken cancellationToken)
    {
        return await service.AddOrUpdateAsync(request);
    }
}